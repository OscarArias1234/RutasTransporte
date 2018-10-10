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

        //trazar una ruta con paradas

        //ruta 01
        private async void ShowRoute01()
        {
            Geolocator locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 1;
            TypedEventHandler<Geolocator, PositionChangedEventArgs> Locator_PositionChanged = null;
            locator.PositionChanged += Locator_PositionChanged;

            BasicGeoposition point1 = new BasicGeoposition() { Latitude = 4.456561, Longitude = -75.181589 };
            BasicGeoposition point2 = new BasicGeoposition() { Latitude = 4.441355, Longitude = -75.192028 };
            BasicGeoposition point3 = new BasicGeoposition() { Latitude = 4.438544, Longitude = -75.191997 };

            // Get Driving Route from point A  to point B thru point C
            var path = new List<EnhancedWaypoint>();

            path.Add(new EnhancedWaypoint(new Geopoint(point1), WaypointKind.Stop));
            path.Add(new EnhancedWaypoint(new Geopoint(point2), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point3), WaypointKind.Stop));

            MapRouteFinderResult routeResult = await MapRouteFinder.GetDrivingRouteFromEnhancedWaypointsAsync(path);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.DeepSkyBlue;
                viewOfRoute.OutlineColor = Colors.Black;

                myMap.Routes.Add(viewOfRoute);

                await myMap.TrySetViewBoundsAsync(
                      routeResult.Route.BoundingBox,
                      null,
                      Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
            }
        }

        //ruta 40
        private async void ShowRoute40()
        {
            Geolocator locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 1;
            TypedEventHandler<Geolocator, PositionChangedEventArgs> Locator_PositionChanged = null;
            locator.PositionChanged += Locator_PositionChanged;

            BasicGeoposition point1 = new BasicGeoposition() { Latitude = 4.456561, Longitude = -75.181589 };
            BasicGeoposition point2 = new BasicGeoposition() { Latitude = 4.441355, Longitude = -75.192028 };
            BasicGeoposition point3 = new BasicGeoposition() { Latitude = 4.438544, Longitude = -75.191997 };
            BasicGeoposition point4 = new BasicGeoposition() { Latitude = 4.433568, Longitude = -75.210501 };
            BasicGeoposition point5 = new BasicGeoposition() { Latitude = 4.435662, Longitude = -75.212379 };
            BasicGeoposition point6 = new BasicGeoposition() { Latitude = 4.438372, Longitude = -75.217572 };
            BasicGeoposition point7 = new BasicGeoposition() { Latitude = 4.440029, Longitude = -75.224440 };
            BasicGeoposition point8 = new BasicGeoposition() { Latitude = 4.443591, Longitude = -75.236015 };
            BasicGeoposition point9 = new BasicGeoposition() { Latitude = 4.444731, Longitude = -75.235493 };
            BasicGeoposition point10 = new BasicGeoposition() { Latitude = 4.445111, Longitude = -75.236074 };
            BasicGeoposition point11 = new BasicGeoposition() { Latitude = 4.445053, Longitude = -75.236429 };
            BasicGeoposition point12 = new BasicGeoposition() { Latitude = 4.441275, Longitude = -75.239144 };
            BasicGeoposition point13 = new BasicGeoposition() { Latitude = 4.440955, Longitude = -75.238870 };
            BasicGeoposition point14 = new BasicGeoposition() { Latitude = 4.438410, Longitude = -75.235271 };
            BasicGeoposition point15 = new BasicGeoposition() { Latitude = 4.438100, Longitude = -75.235250 };
            BasicGeoposition point16 = new BasicGeoposition() { Latitude = 4.437128, Longitude = -75.236745 };
            BasicGeoposition point17 = new BasicGeoposition() { Latitude = 4.440557, Longitude = -75.242512 };
            BasicGeoposition point18 = new BasicGeoposition() { Latitude = 4.440461, Longitude = -75.242856 };
            BasicGeoposition point19 = new BasicGeoposition() { Latitude = 4.435923, Longitude = -75.242737 };
            BasicGeoposition point20 = new BasicGeoposition() { Latitude = 4.419518, Longitude = -75.256453 };
            BasicGeoposition point21 = new BasicGeoposition() { Latitude = 4.419537, Longitude = -75.256498 };
            BasicGeoposition point22 = new BasicGeoposition() { Latitude = 4.419735, Longitude = -75.258112 };
            BasicGeoposition point23 = new BasicGeoposition() { Latitude = 4.418404, Longitude = -75.260334 };
            BasicGeoposition point24 = new BasicGeoposition() { Latitude = 4.416563, Longitude = -75.261975 };
            BasicGeoposition point25 = new BasicGeoposition() { Latitude = 4.414903, Longitude = -75.263337 };
            BasicGeoposition point26 = new BasicGeoposition() { Latitude = 4.413561, Longitude = -75.265621 };

            // Get Driving Route from point A  to point B thru point C
            var path = new List<EnhancedWaypoint>();

            path.Add(new EnhancedWaypoint(new Geopoint(point1), WaypointKind.Stop));
            path.Add(new EnhancedWaypoint(new Geopoint(point2), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point3), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point4), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point5), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point6), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point7), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point8), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point9), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point10), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point11), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point12), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point13), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point14), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point15), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point16), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point17), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point18), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point19), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point20), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point21), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point22), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point23), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point24), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point25), WaypointKind.Via));
            path.Add(new EnhancedWaypoint(new Geopoint(point26 ), WaypointKind.Stop));

            MapRouteFinderResult routeResult = await MapRouteFinder.GetDrivingRouteFromEnhancedWaypointsAsync(path);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.DeepSkyBlue;
                viewOfRoute.OutlineColor = Colors.Black;

                myMap.Routes.Add(viewOfRoute);

                await myMap.TrySetViewBoundsAsync(
                      routeResult.Route.BoundingBox,
                      null,
                      Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
            }
        }

        /* /trazar una ruta entre dos puntos
        private async void ShowRouteOnMap()
        {
            // Start at Microsoft in Redmond, Washington.                       4.456561               -75.181589
            BasicGeoposition startLocation = new BasicGeoposition() { Latitude = 4.456561, Longitude = -75.181589 };

            // End at the city of Seattle, Washington.                         4.448132              -75.179071
            BasicGeoposition endLocation = new BasicGeoposition() { Latitude = 4.411145, Longitude = -75.264982 };


            // Get the route between the points.
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
        } */

        //Ubicaicon de Punto / Ventana emergente a Bing Maps
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowRouteOnMap();
        }
    }
}
