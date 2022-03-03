using System;
using System.Collections.Generic;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter User Names:");
            String input = Console.ReadLine();
            List<String> userList = new List<String>();
            userList.Add(input);
            String inputNewUser = Console.ReadLine();
            userList.Add(inputNewUser);
            System.Console.WriteLine("--New Users--");
            foreach (var user in userList)
            {
                Console.WriteLine(user);
            }
            System.Console.WriteLine("Add another users? y/n:");
            String another = Console.ReadLine();
            if (another == "y")
            {
                String newUser = Console.ReadLine();
                userList.Add(newUser);
                System.Console.WriteLine("---New Users---");
                foreach (var user in userList)
                {
                    Console.WriteLine(user);
                }
            }
            else
            {
                System.Console.WriteLine("Thank you!");
            }

            System.Console.WriteLine("===Generic Collections -INDEX| UPPER CASE| SORTING|===");
            var names = new List<string> { "Ana", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            Console.WriteLine();
            names.Add("Maria");
            names.Add("Bill");
            names.Remove("Ana");
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            Console.WriteLine($"My name is {names[0]}.");
            Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");
            Console.WriteLine($"The list has {names.Count} people in it");
            var index = names.IndexOf("Felipe");
            if (index != -1)
                Console.WriteLine($"The name {names[index]} is at index {index}");

            var notFound = names.IndexOf("Not Found");
            Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");
            names.Sort();
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            Action a = () => Console.Write("a");
            Action b = () => Console.Write("b");

            var abbaab = a + b + b + a + a + b;
            abbaab();  // output: abbaab
            Console.WriteLine();

            var ab = a + b;
            var abba = abbaab - ab;
            abba();  // output: abba
            Console.WriteLine();

            var nihil = abbaab - abbaab;
            Console.WriteLine(nihil is null);  // output: True

System.Console.WriteLine("***** CREATING EVENTS PUBLISHER & SUBSCRIBER | BASE AND DERIVED CLASS *****");
                        //Create the event publishers and subscriber
            var circle = new Circle(54);
            var rectangle = new Rectangle(12, 9);
            var container = new ShapeContainer();

            // Add the shapes to the container.
            container.AddShape(circle);
            container.AddShape(rectangle);

            // Cause some events to be raised.
            circle.Update(57);
            rectangle.Update(7, 7);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

            public class SampleEventArgs
        {
            public SampleEventArgs(string text) { Text = text; }
            public string Text { get; } // readonly
        }

        public class Publisher
        {
            // Declare the delegate (if using non-generic pattern).
            public delegate void SampleEventHandler(object sender, SampleEventArgs e);

            // Declare the event.
            public event SampleEventHandler SampleEvent;

            // Wrap the event in a protected virtual method
            // to enable derived classes to raise the event.
            protected virtual void RaiseSampleEvent()
            {
                // Raise the event in a thread-safe manner using the ?. operator.
                SampleEvent?.Invoke(this, new SampleEventArgs("Hello"));
            }
        }


    public class ShapeEventArgs : EventArgs
    {
        public ShapeEventArgs(double area)
        {
            NewArea = area;
        }

        public double NewArea { get; }
    }

    // Base class event publisher
    public abstract class Shape
    {
        protected double _area;

        public double Area
        {
            get => _area;
            set => _area = value;
        }

        // The event. Note that by using the generic EventHandler<T> event type
        // we do not need to declare a separate delegate type.
        public event EventHandler<ShapeEventArgs> ShapeChanged;

        public abstract void Draw();

        //The event-invoking method that derived classes can override.
        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            // Safely raise the event for all subscribers
            ShapeChanged?.Invoke(this, e);
        }
    }

    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
            _area = 3.14 * _radius * _radius;
        }

        public void Update(double d)
        {
            _radius = d;
            _area = 3.14 * _radius * _radius;
            OnShapeChanged(new ShapeEventArgs(_area));
        }

        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            // Do any circle-specific processing here.

            // Call the base class event invocation method.
            base.OnShapeChanged(e);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }

    public class Rectangle : Shape
    {
        private double _length;
        private double _width;

        public Rectangle(double length, double width)
        {
            _length = length;
            _width = width;
            _area = _length * _width;
        }

        public void Update(double length, double width)
        {
            _length = length;
            _width = width;
            _area = _length * _width;
            OnShapeChanged(new ShapeEventArgs(_area));
        }

        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            // Do any rectangle-specific processing here.

            // Call the base class event invocation method.
            base.OnShapeChanged(e);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }

    // Represents the surface on which the shapes are drawn
    // Subscribes to shape events so that it knows
    // when to redraw a shape.
    public class ShapeContainer
    {
        private readonly List<Shape> _list;

        public ShapeContainer()
        {
            _list = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            _list.Add(shape);

            // Subscribe to the base class event.
            shape.ShapeChanged += HandleShapeChanged;
        }

        // ...Other methods to draw, resize, etc.

        private void HandleShapeChanged(object sender, ShapeEventArgs e)
        {
            if (sender is Shape shape)
            {
                // Diagnostic message for demonstration purposes.
                Console.WriteLine($"Received event. Shape area is now {e.NewArea}");

                // Redraw the shape here.
                shape.Draw();
            }
        }
    }
        public class MyClass
        {
            public delegate void SampleEvent();
            public event SampleEvent SE;
            
            public virtual void RaiseSE()
            {

            }
        }
    }
}

