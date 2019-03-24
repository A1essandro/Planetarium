using Planetarium;
using PlanetariumWpf.Model;
using PlanetariumWpf.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlanetariumWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly FrameManager _frameManager;
        private readonly Gravity _gravity = new Gravity(0.001);
        private readonly CollisionManager<Planet> _collisionManager = new CollisionManager<Planet>(new AfterCollisionPlanetFactory());

        public MainWindow()
        {
            InitializeComponent();

            World.MouseLeftButtonUp += AddEntity;
            World.MouseWheel += ChangeScale;

            _frameManager = new FrameManager(TimerTick, true);

            DataContext = new EntityOnWindowVM();
        }

        private async void TimerTick(object sender, EventArgs e)
        {
            var context = DataContext as EntityOnWindowVM;

            var planets = context.Entities.OfType<Planet>();
            await Task.Run(() => _gravity.RecalculateSpeed(planets));

            World.Children.Clear();
            foreach (var entity in context.Entities.OfType<Planet>())
            {
                entity.Move();
                World.Children.Add(entity.GetRenderElement());
            }

            var collisionsResult = _collisionManager.CheckCollisions(planets);
            foreach (var toRemove in collisionsResult.DestroyedObjects)
                context.Entities.Remove(toRemove);
            foreach (var toAdd in collisionsResult.NewObjects)
                context.Entities.Add(toAdd);
        }

        private void ChangeScale(object sender, MouseWheelEventArgs e)
        {
            var scale = WorldState.Scale;
            if (e.Delta < 0)
            {
                scale *= 0.95;
            }
            else
            {
                scale *= 1.045;
            }

            if (scale < 0.25)
                scale = 0.25;
            else if (scale > 10)
                scale = 10;

            WorldState.Scale = Math.Round(scale, 2);
        }

        private void AddEntity(object sender, MouseButtonEventArgs e)
        {
            var context = DataContext as EntityOnWindowVM;

            var rand = new Random();
            var size = rand.Next() % 9 + 1;
            var point = e.GetPosition(this);
            var position = new VectorAndPoint.ValTypes.Point(point.X / WorldState.Scale, point.Y / WorldState.Scale);

            context.Entities.Add(new Planet(size, position));
        }

    }
}
