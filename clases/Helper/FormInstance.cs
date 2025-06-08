using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MECANOGRAFIA.clases.Helper
{
    public  class FormInstance
    {
        private List<Form> forms = new List<Form>();
        public void ShowForm<T>(Action<Form> OwnedForm) where T : Form, new()
        {
            T form = forms.OfType<T>().FirstOrDefault();
            if (form == null)
            {
                form = new T();
                OwnedForm(form);
                forms.Add(form);
            }
            form.ShowDialog();
        }
    }
}
