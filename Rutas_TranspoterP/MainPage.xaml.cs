using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Rutas_TranspoterP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double miLatitud = 0;
        double miLongitud = 0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void myMap_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            int vista = cmbVista.SelectedIndex;
            double longi = 0;
            double lati = 0;
            switch (vista)
            {
                case 0:
                    lati = 4.439730; longi = -75.223361;
                    showStreetsideView(lati, longi);
                    break;
                case 1:
                    lati = 4.439730; longi = -75.223361;
                    showStreetsideView(lati, longi);
                    break;
                case 2:
                    lati = 4.439730; longi = -75.223361;
                    display3DLocation(lati, longi);
                    break;
            }
        }

        private void SpaceNeedle_Click(object sender, RoutedEventArgs e)
        {
            Geopoint spaceNeedlePoint = new Geopoint
                (new BasicGeoposition { Latitude = 4.457118, Longitude = -75.181588 });

            PlaceInfoCreateOptions options = new PlaceInfoCreateOptions();

            options.DisplayAddress = "400 Broad St, Seattle, WA 98109";
            options.DisplayName = "Seattle Space Needle";

            PlaceInfo spaceNeedlePlace = PlaceInfo.Create(spaceNeedlePoint, options);

            FrameworkElement targetElement = (FrameworkElement)sender;

            GeneralTransform generalTransform =
                targetElement.TransformToVisual((FrameworkElement)targetElement.Parent);

            Rect rectangle = generalTransform.TransformBounds(new Rect(new Point
                (targetElement.Margin.Left, targetElement.Margin.Top), targetElement.RenderSize));

            spaceNeedlePlace.Show(rectangle, Windows.UI.Popups.Placement.Below);
        }

        //Streetview
        private async void showStreetsideView(double lati, double longi)
        {
            // Check if Streetside is supported.
            if (myMap.IsStreetsideSupported)
            {
                // Find a panorama near Avenue Gustave Eiffel.
                BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = lati, Longitude = longi };
                Geopoint cityCenter = new Geopoint(cityPosition);
                StreetsidePanorama panoramaNearCity = await StreetsidePanorama.FindNearbyAsync(cityCenter);

                // Set the Streetside view if a panorama exists.
                if (panoramaNearCity != null)
                {
                    // Create the Streetside view.
                    StreetsideExperience ssView = new StreetsideExperience(panoramaNearCity);
                    ssView.OverviewMapVisible = true;
                    myMap.CustomExperience = ssView;
                }
            }
            else
            {
                // If Streetside is not supported
                ContentDialog viewNotSupportedDialog = new ContentDialog()
                {
                    Title = "Streetside is not supported",
                    Content = "\nStreetside views are not supported on this device.",
                    PrimaryButtonText = "OK"
                };
                await viewNotSupportedDialog.ShowAsync();
            }
        }

        //Vista en 3d
        private async void display3DLocation(double lati, double longi)
        {
            if (myMap.Is3DSupported)
            {
                // Set the aerial 3D view.
                myMap.Style = MapStyle.Aerial3DWithRoads;

                // Specify the location.

                //  43.773251
                //     11.255474

                BasicGeoposition hwGeoposition = new BasicGeoposition() { Latitude = lati, Longitude = longi };
                Geopoint hwPoint = new Geopoint(hwGeoposition);

                // Create the map scene.
                MapScene hwScene = MapScene.CreateFromLocationAndRadius(hwPoint,
                                                                                     80, /* show this many meters around */
                                                                                     0, /* looking at it to the North*/
                                                                                     60 /* degrees pitch */);
                // Set the 3D view with animation.
                await myMap.TrySetSceneAsync(hwScene, MapAnimationKind.Bow);
            }
            else
            {
                // If 3D views are not supported, display dialog.
                ContentDialog viewNotSupportedDialog = new ContentDialog()
                {
                    Title = "3D is not supported",
                    Content = "\n3D views are not supported on this device.",
                    PrimaryButtonText = "OK"
                };
                await viewNotSupportedDialog.ShowAsync();
            }
        }

        //Tomar ubicación actual
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 4.429893, Longitude = -75.214561 };
            Geopoint cityCenter = new Geopoint(cityPosition);
            // Set the map location.
            myMap.Center = cityCenter;
            myMap.ZoomLevel = 12;
            myMap.LandmarksVisible = true;

            // Set your current location.
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    // Get the current location.
                    Geolocator geolocator = new Geolocator();
                    Geoposition pos = await geolocator.GetGeopositionAsync();
                    Geopoint myLocation = pos.Coordinate.Point;

                    // Set the map location.
                    myMap.Center = myLocation;
                    myMap.ZoomLevel = 12;
                    myMap.LandmarksVisible = true;

                    miLatitud = myLocation.Position.Latitude;
                    miLongitud = myLocation.Position.Longitude;
                    break;

                case GeolocationAccessStatus.Denied:
                    // Handle the case  if access to location is denied.
                    break;

                case GeolocationAccessStatus.Unspecified:
                    // Handle the case if  an unspecified error occurs.
                    break;
            }
        }

        //Mostrar rutas
        private async void ShowRouteOnMap(double lati, double longi)
        {
            //posicion actual
            BasicGeoposition startLocation = new BasicGeoposition() { Latitude = miLatitud, Longitude = miLongitud };

            // posicion final
            BasicGeoposition endLocation = new BasicGeoposition() { Latitude = lati, Longitude = longi };


            // Obtener ruta
            MapRouteFinderResult routeResult =
                  await MapRouteFinder.GetDrivingRouteAsync(
                  new Geopoint(startLocation),
                  new Geopoint(endLocation),
                  MapRouteOptimization.Time,
                  MapRouteRestrictions.None);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                // Use the route to initialize a MapRouteView.
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.Yellow;
                viewOfRoute.OutlineColor = Colors.Black;

                // Add the new MapRouteView to the Routes collection
                // of the MapControl.
                myMap.Routes.Add(viewOfRoute);

                // Fit the MapControl to the route.
                await myMap.TrySetViewBoundsAsync(
                      routeResult.Route.BoundingBox,
                      null,
                      Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
            }
        }

     
    }
}
