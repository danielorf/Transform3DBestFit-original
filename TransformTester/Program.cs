using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Storage;
using System.Web.UI.DataVisualization.Charting;

namespace Transform3DBestFit
{
    class Program
    {
        static void Main(string[] args)
        {

            //double[,] actualsArray = new double[,]
            //{
            //    {-706.8029, 4402.2612, -698.6121},
            //    {3943.6384, 277.1709, 1620.0882},
            //    {-3888.6095, -1470.2581, -521.8029},
            //    {-188.7196, 733.4562, -5282.4335},
            //    {3299.2840, 1533.9865, -3723.8831}
            //};

            ////point cloud at finished position
            //double[,] nominalsArray = new double[,]
            //{
            //    {-564.0000, -649.0000, -880.0000},
            //    {-590.0000, 674.0000, -214.0000},
            //    {-57.0000, -863.0000, 436.0000},
            //    {287.0000, -986.0000, 125.0000},
            //    {-791.0000, 46.0000, -358.0000}
            //};

            //double[,] actualsArray = new double[,]
            //{
            //    {1172.461974,	448.9081115,	-5838.265552},
            //    {595.8638081,	7969.187566,	-7327.886837},
            //    {1236.371337,	-6968.735029,	-8819.736879},
            //    {810.6022162,	-6018.888489,	-2377.61751},
            //    {-5463.381268,	-7697.603744,	-7439.627755}
            //};

            ////point cloud at finished position
            //double[,] nominalsArray = new double[,]
            //{
            //    {3834,531,718},
            //    {5284,7953,2106},
            //    {6780,-6539,-1534},
            //    {322,-5662,-1076},
            //    {4764,-5435,-8016}
            //};

            double[,] actualsArray = new double[,]
            {
                {130.7602388,-201.4698323,-350.4367024},
                {-794.5655996,605.7337752,-225.9470533},
                {-657.3526696,538.7284438,910.710878}
            };

            //point cloud at finished position
            double[,] nominalsArray = new double[,]
            {
                {5.917773607,958.4597562,521.2598757},
                {-148.7424555,-482.7015272,60.75342652},
                {-886.2499607,106.8092234,19.86599164}
            };


            //BestFit3DTransform transform = new BestFit3DTransform();
            Transform3D Transform = new Transform3D(actualsArray, nominalsArray);

            bool d = Transform.CalcTransform(Transform.actualsMatrix, Transform.nominalsMatrix);

            Console.WriteLine("Tranform Matrix");
            Console.WriteLine(Matrix<double>.Build.DenseOfArray(Transform.TransformMatrix));
            Console.WriteLine();
            //Console.WriteLine("Translation Matrix");
            //Console.WriteLine(Matrix<double>.Build.DenseOfArray(Transform.TranslationMatrix));
            //Console.WriteLine();
            Console.WriteLine("Tranform Vector");
            Console.WriteLine(Vector<double>.Build.DenseOfArray(Transform.Transform6DOFVector));
            Console.WriteLine();
            Console.WriteLine("Tranform Vector Siemens");
            Console.WriteLine(Vector<double>.Build.DenseOfArray(Transform.TransformSiemens6DOFVector));
            Console.WriteLine();
            Console.WriteLine("Final Error RMS = ");
            Console.WriteLine(Transform.ErrorRMS.ToString());
            Console.WriteLine();

            

        }
    }
}



////BestFit3DTransform transform = new BestFit3DTransform();
//Transform3D Transform = new Transform3D(actualsArray, nominalsArray);

//double[,] trans = new double[4,4];
//double err = new double();
//double rotDeterminant;
//bool d = Transform.CalcTransform(Transform.actualsMatrix, Transform.nominalsMatrix, out trans, out err, out rotDeterminant);
