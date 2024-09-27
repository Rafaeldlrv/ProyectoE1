using System.Globalization;

namespace Conversor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btcon_Click(object sender, EventArgs e)
        {
            string input = tbtnum.Text;  // Número ingresado por el usuario
            string selectedSystem = comboBox1.SelectedItem.ToString();  // Sistema seleccionado (Decimal o Hexadecimal)
            string selectedBits = comboBox2.SelectedItem.ToString(); // Tamaño en bits seleccionado

            try
            {
                if (selectedSystem == "HEXADECIMAL")
                {
                    if (selectedBits == "16")
                    {
                        string hexValue = input;
                        byte[] bytes = new byte[2];

                        for (int i = 0; i < 2; i++)
                        {
                            bytes[i] = Convert.ToByte(hexValue.Substring(i * 2, 2), 16);
                        }

                        ushort ushortValue = BitConverter.ToUInt16(bytes, 0);

                        // descomponer el valor en sus componentes de IEEE 754
                        int sign = (ushortValue >> 15) & 0x0001;
                        int exponent = (ushortValue >> 10) & 0x001F;
                        int fraction = ushortValue & 0x03FF;

                        // Calcular el valor decimal
                        float decimalValue;
                        if (exponent == 0 && fraction == 0)
                        {
                            // es cero
                            decimalValue = 0.0f;
                        }
                        else if (exponent == 31)
                        {
                            // infinitos o NaN
                            decimalValue = fraction == 0 ? float.PositiveInfinity : float.NaN;
                        }
                        else
                        {
                            // exp normalizado
                            if (exponent == 0)
                            {
                                // numeros pequeños
                                decimalValue = (float)(Math.Pow(-1, sign) * (fraction / Math.Pow(2, 10)) * Math.Pow(2, -14));
                            }
                            else
                            {
                                // normales
                                decimalValue = (float)(Math.Pow(-1, sign) * (1 + (fraction / Math.Pow(2, 10))) * Math.Pow(2, exponent - 15));
                            }
                            tbtie.Text = decimalValue.ToString();
                        }
                    }
                    else if (selectedBits == "32")
                    {
                        string hexValue = input;
                        if (hexValue.Length != 8)
                        {
                            tbtie.Text = "ERROR";
                        }
                        // Convertir hexadecimal a un array de bytes (32 bits)
                        byte[] bytes = new byte[4];
                        for (int i = 0; i < 4; i++)
                        {
                            bytes[i] = Convert.ToByte(hexValue.Substring(i * 2, 2), 16);
                        }
                        // Convertir los bytes a un número de punto flotante de 32 bits
                        float floatValue = BitConverter.ToSingle(bytes, 0);
                        tbtie.Text = floatValue.ToString();
                    }
                    else if (selectedBits == "64")
                    {
                        string hexValue = input;
                        if (hexValue.Length != 16)
                        {
                            tbtie.Text = "ERROR";
                        }
                        // Convertir hexadecimal a un array de bytes (32 bits)
                        byte[] bytes = new byte[8];
                        for (int i = 0; i < 8; i++)
                        {
                            bytes[i] = Convert.ToByte(hexValue.Substring(i * 2, 2), 16);
                        }
                        // Convertir los bytes a un número de punto flotante de 32 bits
                        double doubleValue = BitConverter.ToDouble(bytes, 0);
                        tbtie.Text = doubleValue.ToString();
                    }
                }
                else if (selectedSystem == "DECIMAL")
                {
                    if (selectedBits == "16")
                    {
                        String decnum = input;
                        float decimalNumber = float.Parse(decnum);

                        int floatBits = BitConverter.ToInt32(BitConverter.GetBytes(decimalNumber), 0);
                        int sign = (floatBits >> 31) & 0x1;
                        int exponent = (floatBits >> 23) & 0xFF;
                        int mantissa = floatBits & 0x7FFFFF;

                        // ajuste para 16 bits
                        int halfExponent = exponent - 127 + 15;

                        // control de casos especiales
                        if (exponent == 255) // Infinito o NaN
                        {
                            halfExponent = 31;
                            mantissa = mantissa != 0 ? 1 : 0; // si mantissa es diferente de 0
                        }
                        else if (halfExponent >= 31) // Overflow a infinito
                        {
                            halfExponent = 31;
                            mantissa = 0;
                        }
                        else if (halfExponent <= 0) // invalido
                        {
                            if (halfExponent < -10) // numero es demasiado pequeño
                            {
                                ushort halfPre = (ushort)(sign << 15);
                                string hexZero = halfPre.ToString("X4");
                                tbtie.Text = hexZero.ToString();
                                return;
                            }

                            // hace lo de quitar el 1
                            mantissa = (mantissa | 0x800000) >> (1 - halfExponent);
                            halfExponent = 0;
                        }

                        // Redondear mantissa
                        mantissa = mantissa >> 13;

                        // Empaquetar el resultado en 16 bits
                        ushort halfPrecision = (ushort)((sign << 15) | (halfExponent << 10) | mantissa);

                        // invertir el orden
                        byte[] halfPrecisionBytes = BitConverter.GetBytes(halfPrecision);
                        Array.Reverse(halfPrecisionBytes); // Invertir el orden para little-endian

                        ushort littleEndianHalfPrecision = BitConverter.ToUInt16(halfPrecisionBytes, 0);
                        string hex = littleEndianHalfPrecision.ToString("X4");
                        tbtie.Text = hex.ToString();

                    }
                    else if (selectedBits == "32")
                    {
                        String decValue = input;
                        float decimalNumber = float.Parse(decValue);
                        byte[] byteArray = BitConverter.GetBytes(decimalNumber);

                        // Convertir los bytes a hexadecimal
                        string hex = BitConverter.ToString(byteArray).Replace("-", "");

                        tbtie.Text = hex.ToString();
                    }
                    else if (selectedBits == "64")
                    {
                        String decValue = input;
                        double decimalNumber = double.Parse(decValue);
                        byte[] byteArray = BitConverter.GetBytes(decimalNumber);

                        // Convertir los bytes a hexadecimal
                        string hex = BitConverter.ToString(byteArray).Replace("-", "");

                        tbtie.Text = hex.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                // Muestra comboBox2 y agrega las opciones 16, 32, 64
                comboBox2.Items.Clear();
                comboBox2.Items.Add("16");
                comboBox2.Items.Add("32");
                comboBox2.Items.Add("64");
                comboBox2.Visible = true;
                label2.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}