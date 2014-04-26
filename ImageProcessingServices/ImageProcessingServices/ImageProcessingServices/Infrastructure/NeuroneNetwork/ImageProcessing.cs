using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ImageProcessingServices.Infrastructure.NeuroneNetwork
{
    /// <summary>
    /// Helper class for image processing. It generates a matrix of the features of a bitmap file or scales an image.
    /// </summary>
    public class ImageProcessing
    {
        /// <summary>
        /// Converts an RGB bitmap to a Matrix
        /// </summary>
        /// <param name="bitmap">Image to be mapped to a matrix</param>
        /// <param name="matrixRowCount">Row count of the matrix</param>
        /// <param name="matrixColumnCount">Column count of the matrix</param>
        /// <returns>Matrix with mapped features of a bitmap pixels to matrix elements</returns>
        public static double[] ToMatrix(Bitmap bitmap, int matrixRowCount, int matrixColumnCount)
        {
            double HRate = ((Double)matrixRowCount / bitmap.Height);
            double WRate = ((Double)matrixColumnCount / bitmap.Width);
            double[] Result = new double[matrixColumnCount * matrixRowCount];

            for (int r = 0; r < matrixRowCount; r++)
            {
                for (int c = 0; c < matrixColumnCount; c++)
                {
                    Color color = bitmap.GetPixel((int)(c / WRate), (int)(r / HRate));
                    Result[r * matrixColumnCount + c] = 1 - (color.R * .3 + color.G * .59 + color.B * .11) / 255;
                }
            }
            return Result;
        }

        /// <summary>
        /// Rescaling of a bitmap image.
        /// </summary>
        /// <param name="bitmap">Image to rescale</param>
        /// <param name="newHeight">Height of the new image</param>
        /// <param name="newWidth">Width of the new image</param>
        /// <returns>The rescaled bitmap</returns>
        public static Bitmap ScaleImage(Bitmap bitmap, int newHeight, int newWidth)
        {
            double HRate = (double)bitmap.Height / newHeight;
            double WRate = (double)bitmap.Width / newWidth;
            Bitmap Result = new Bitmap(newWidth, newHeight);
            for (int i = 0; i < newHeight; i++)
            {
                for (int j = 0; j < newWidth; j++)
                {
                    int x = (int)((double)j * WRate);
                    int y = (int)((double)i * HRate);
                    Result.SetPixel(j, i, bitmap.GetPixel(x, y));
                }
            }

            return Result;
        }
    }
}