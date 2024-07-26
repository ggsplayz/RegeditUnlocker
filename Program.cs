using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace EnableRegistryEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Ruta del registro donde se encuentra la clave
                string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";

                // Abre la clave del registro, o crea una nueva si no existe
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        // Establece el valor de DisableRegistryTools a 0 (habilitado)
                        key.SetValue("DisableRegistryTools", 0, RegistryValueKind.DWord);

                        MessageBox.Show("Registry Editor was enabled successfully.", "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registry Editor wasn´t enabled successfully", "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
