using PolygonLibrary;
using PolygonLibrary.Exceptions;
using System;
using System.IO;
using System.Linq;
using DU = App.DisplayUtility;

namespace App
{
    internal class Program
    {
        private static readonly string DefaultFilePath = "samplePolygon.txt";
        private static readonly Vertex DefaultInitialVertex = new Vertex(0, 0);

        private static void Main(string[] args)
        {
            try
            {
                AppParameters parameters = ExtractParametersFromInput(args);
                ProcessInput(parameters);

                DU.DisplayText("Press any key to close the program...");
            }
            catch (InputValidationException e)
            {
                DU.DisplayText(e.Message, DU.InformationType.OnError);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Converts command line arguments to application parameters
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>Parsed application parameters</returns>
        private static AppParameters ExtractParametersFromInput(string[] args)
        {
            if (args.Length != 3)
            {
                throw new InputValidationException("You must provide 3 arguments to the program: number of vertices, side length, save option ('c' - console, 'f' - file 'polygon' in current directory).");
            }

            if (!(int.TryParse(args[0], out int numberOfVertices) && double.TryParse(args[0], out double sideLength)))
            {
                throw new InputValidationException("Something went wrong while parsing. Next time ensure that the parameters' format is correct.");
            }

            char option = args[2].ToUpperInvariant().ToCharArray()[0];
            if (!new[] { 'C', 'F' }.Contains(option))
            {
                throw new InputValidationException("Unknown save/display option.");
            }

            return new AppParameters()
            {
                NumberOfVertices = numberOfVertices,
                SideLength = sideLength,
                Option = option == 'C' ? AppParameters.ProcessType.DisplayOnConsole : AppParameters.ProcessType.SaveToFile
            };
        }

        /// <summary>
        /// Given the application parameters, creates regular polygon and depending on the option: saves it to default file or displays it on console
        /// /// </summary>
        /// <param name="parameters">Already parsed application parameters</param>
        private static void ProcessInput(AppParameters parameters)
        {
            RegularPolygonFactory factory = new RegularPolygonFactory();
            try
            {
                RegularPolygon polygon =
                    factory.CreateRegularPolygon(parameters.NumberOfVertices, parameters.SideLength, DefaultInitialVertex);
                switch (parameters.Option)
                {
                    case AppParameters.ProcessType.DisplayOnConsole:
                        DU.DisplayText(polygon.ToString());
                        DU.DisplayText("Successfully completed operation", DU.InformationType.OnSuccess);
                        break;

                    case AppParameters.ProcessType.SaveToFile:
                        SavePolygonToFile(DefaultFilePath, polygon);
                        break;
                }
            }
            catch (RegularPolygonFactoryLogicalException e)
            {
                DU.DisplayText(e.Message, DU.InformationType.OnError);
            }
        }

        /// <summary>
        /// Saves the polygon to the specified file.
        /// </summary>
        /// <param name="filePath">Filepath</param>
        /// <param name="polygon">Regular polygon to save</param>
        private static void SavePolygonToFile(string filePath, RegularPolygon polygon)
        {
            try
            {
                File.WriteAllText(filePath, polygon.ToString());
                DU.DisplayText("Successfully completed operation", DU.InformationType.OnSuccess);
            }
            catch (Exception e)
            {
                DU.DisplayText(e.Message, DU.InformationType.OnError);
            }
        }
    }
}