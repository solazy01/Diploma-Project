using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Runge
    {
        public delegate float myF(float x, float[] y, int n);

        public float[] RungeR(float x0, float[] y, myF[] f, int n, float h)
        {
            int j, i;
            float[] y_new = new float[n];
            float[] k1 = new float[n];
            float[] k2 = new float[n];
            float[] k3 = new float[n];
            float[] k4 = new float[n];
            float x = x0;
            for (j = 0; j < n; j++)
                k1[j] = h * f[j](x, y, n);
            for (i = 0; i < n; i++)
                y_new[i] = y[i] + 0.5f * k1[i];
            for (j = 0; j < n; j++)
                k2[j] = h * f[j](x + 0.5f * h, y_new, n);
            for (i = 0; i < n; i++)
                y_new[i] = y[i] + 0.5f * k2[i];
            for (j = 0; j < n; j++)
                k3[j] = h * f[j](x + 0.5f * h, y_new, n);
            for (i = 0; i < n; i++)
                y_new[i] = y[i] + k3[i];
            for (j = 0; j < n; j++)
                k4[j] = h * f[j](x + h, y_new, n);
            for (i = 0; i < n; i++)
                y_new[i] = y[i] + (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]) / 6;
            return y_new;
        }
       
    }
}
