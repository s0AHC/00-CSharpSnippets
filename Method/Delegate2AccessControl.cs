        //用代理跨线程读取control的值
        public delegate int ComboBoxDelegate(ComboBox cmb);
        public int DelegateComboBox(ComboBox cmb)
        {
            if (cmb.InvokeRequired)
            {
                // option1: return (int)cmb.Invoke(new ComboBoxDelegate(DelegateCmb), cmb);
                // Or 
                //option2:
                ComboBoxDelegate dtcmb = new ComboBoxDelegate(DelegateComboBox);
                IAsyncResult iar = cmb.BeginInvoke(dtcmb, new object[] { cmb });
                return (int)cmb.EndInvoke(iar);
            }
            else
            {
                return (int)cmb.SelectedValue;
            }
        }

        public delegate string txtDelegate(TextBox txt);
        public string DelegateTextBox(TextBox txt)
        {
            if (txt.InvokeRequired)
            {
                return (string)txt.Invoke(new txtDelegate(DelegateTextBox), txt);
            }
            else
            {
                return txt.Text.Trim();
            }
        }

        public delegate string mskTxtDelegate(MaskedTextBox msktxt);
        public string DelegateMskTextBox(MaskedTextBox msktxt)
        {
            if (msktxt.InvokeRequired)
            {
                return (string)msktxt.Invoke(new mskTxtDelegate(DelegateMskTextBox), msktxt);
            }
            else
            {
                return msktxt.Text;
            }                
        }