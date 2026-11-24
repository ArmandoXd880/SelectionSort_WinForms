using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SelectionSortDemo
{
    public sealed class MainForm : Form
    {
        private readonly ComboBox mode = new ComboBox();
        private readonly TextBox input = new TextBox();
        private readonly Label status = new Label();
        private readonly Label explanation = new Label();
        private readonly Label indices = new Label();
        private readonly Label pending = new Label();
        private readonly FlowLayoutPanel array = new FlowLayoutPanel();
        private readonly ListBox code = new ListBox();
        private readonly Button previous = new Button(), next = new Button(), play = new Button();
        private readonly Timer timer = new Timer();
        private readonly NumericUpDown delay = new NumericUpDown();
        private List<Step> steps = new List<Step>();
        private int cursor;
        private bool loading;

        public MainForm()
        {
            Text = "Selection Sort · Paso a paso";
            Font = new Font("Segoe UI", 11F);
            BackColor = Color.FromArgb(246, 248, 252);
            ClientSize = new Size(1280, 800);
            MinimumSize = new Size(1050, 740);
            StartPosition = FormStartPosition.CenterScreen;
            AutoScaleMode = AutoScaleMode.Dpi;

            TableLayoutPanel root = new TableLayoutPanel();
            root.Dock = DockStyle.Fill; root.Padding = new Padding(20); root.ColumnCount = 1; root.RowCount = 9;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 44));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 54));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 76));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
            Controls.Add(root);

            Label heading = new Label { Text = "SELECTION SORT   /   Ordenamiento por selección", AutoSize = true,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold), ForeColor = Color.FromArgb(24, 43, 72) };
            root.Controls.Add(heading, 0, 0);

            FlowLayoutPanel toolbar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false };
            mode.DropDownStyle = ComboBoxStyle.DropDownList; mode.Width = 135;
            mode.Items.AddRange(new object[] { "Números", "Letras", "Palabras" });
            input.Width = 410;
            Button generate = MakeButton("Cargar / reiniciar", 157);
            Button example = MakeButton("Ejemplo", 100);
            toolbar.Controls.Add(mode); toolbar.Controls.Add(input); toolbar.Controls.Add(generate); toolbar.Controls.Add(example);
            root.Controls.Add(toolbar, 0, 1);
            pending.Dock = DockStyle.Fill; pending.ForeColor = Color.FromArgb(120, 70, 10);
            root.Controls.Add(pending, 0, 2);
            Label hint = new Label { Text = "1 a 12 elementos separados por comas o espacios. Texto: orden español, sin distinguir mayúsculas.", Dock = DockStyle.Fill };
            root.Controls.Add(hint, 0, 3);

            array.Dock = DockStyle.Fill; array.AutoScroll = true; array.WrapContents = false; array.BackColor = Color.White;
            ResizeEnd += delegate { if (steps.Count > 0) ShowStep(); };
            root.Controls.Add(array, 0, 4);
            FlowLayoutPanel legend = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = true };
            Legend(legend, "ORD: posición definitiva", Color.FromArgb(220, 252, 231));
            Legend(legend, "MIN: mínimo provisional", Color.FromArgb(254, 240, 138));
            Legend(legend, "J: se compara", Color.FromArgb(224, 242, 254));
            Legend(legend, "CAMBIO: intercambio", Color.FromArgb(252, 231, 243));
            root.Controls.Add(legend, 0, 5);

            TableLayoutPanel textArea = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1 };
            textArea.RowStyles.Add(new RowStyle(SizeType.Absolute, 25)); textArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            indices.Dock = DockStyle.Fill; indices.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            explanation.Dock = DockStyle.Fill; explanation.Font = new Font("Segoe UI", 12F);
            textArea.Controls.Add(indices, 0, 0); textArea.Controls.Add(explanation, 0, 1); root.Controls.Add(textArea, 0, 6);

            FlowLayoutPanel navigation = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false };
            ConfigureButton(previous, "Anterior", 108); ConfigureButton(next, "Siguiente", 108); ConfigureButton(play, "Automático", 115);
            delay.Minimum = 300; delay.Maximum = 5000; delay.Increment = 100; delay.Value = 1400; delay.Width = 76;
            navigation.Controls.Add(previous); navigation.Controls.Add(next); navigation.Controls.Add(play);
            navigation.Controls.Add(new Label { Text = "Pausa (ms):", AutoSize = true, Margin = new Padding(12, 8, 0, 0) });
            navigation.Controls.Add(delay);
            status.AutoSize = true; status.Margin = new Padding(15, 8, 0, 0); navigation.Controls.Add(status);
            root.Controls.Add(navigation, 0, 7);

            code.Dock = DockStyle.Fill; code.Font = new Font("Consolas", 10F); code.IntegralHeight = false;
            code.Items.AddRange(new object[] {
                "0  Inicio: arreglo sin ordenar",
                "1  for i = 0 hasta n - 2: min = i",
                "2      for j = i + 1 hasta n - 1",
                "3          if Comparar(a[j], a[min]) < 0",
                "4              min = j",
                "5      if min != i",
                "6          intercambiar a[i] y a[min]",
                "7      a[i] queda definitivo",
                "8  Fin: el último elemento también queda ordenado" });
            root.Controls.Add(code, 0, 8);

            generate.Click += delegate { LoadSteps(); };
            example.Click += delegate { SetExample(); };
            previous.Click += delegate { Stop(); if (cursor > 0) cursor--; ShowStep(); };
            next.Click += delegate { Stop(); Advance(); };
            play.Click += delegate {
                if (timer.Enabled) { Stop(); return; }
                if (cursor >= steps.Count - 1) cursor = 0;
                timer.Interval = (int)delay.Value; timer.Start(); ShowStep();
            };
            timer.Tick += delegate { Advance(); };
            delay.ValueChanged += delegate { timer.Interval = (int)delay.Value; };
            mode.SelectedIndexChanged += delegate { if (!loading) SetExample(); };
            input.TextChanged += delegate {
                if (loading) return;
                Stop(); steps.Clear(); cursor = 0; array.Controls.Clear();
                explanation.Text = "Pulsa Cargar / reiniciar para ordenar estos datos.";
                pending.Text = "Datos modificados: falta cargar."; indices.Text = ""; status.Text = "";
                previous.Enabled = next.Enabled = play.Enabled = false; code.ClearSelected();
            };
            FormClosed += delegate { timer.Dispose(); };
            mode.SelectedIndex = 0;
        }

        private static Button MakeButton(string text, int width)
        { Button b = new Button(); ConfigureButton(b, text, width); return b; }
        private static void ConfigureButton(Button b, string text, int width)
        { b.Text = text; b.Width = width; b.Height = 34; b.UseVisualStyleBackColor = true; }
        private static void Legend(FlowLayoutPanel host, string text, Color color)
        { host.Controls.Add(new Label { Text = text, AutoSize = true, BackColor = color, Padding = new Padding(5), Margin = new Padding(3) }); }

        private void SetExample()
        {
            Stop(); loading = true;
            input.Text = mode.SelectedIndex == 0 ? SelectionEngine.NumberExample : mode.SelectedIndex == 1 ? "C, A, B" : "sol, ave, luna";
            loading = false; LoadSteps();
        }
        private void LoadSteps()
        {
            Stop();
            try {
                steps = SelectionEngine.Build(SelectionEngine.Parse(input.Text, mode.SelectedIndex), mode.SelectedIndex);
                cursor = 0; pending.Text = "Datos cargados. Cada clic muestra una sola acción."; ShowStep();
            }
            catch (ArgumentException ex) {
                steps.Clear(); array.Controls.Clear(); previous.Enabled = next.Enabled = play.Enabled = false;
                MessageBox.Show(this, ex.Message, "Revisa los datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Stop() { timer.Stop(); play.Text = "Automático"; }
        private void Advance()
        {
            if (cursor < steps.Count - 1) cursor++;
            if (cursor >= steps.Count - 1) Stop();
            ShowStep();
        }
        private void ShowStep()
        {
            if (steps.Count == 0) return;
            Step s = steps[cursor];
            array.SuspendLayout();
            // Dispose de las tarjetas antiguas para liberar controles al navegar.
            while (array.Controls.Count > 0) { Control c = array.Controls[0]; array.Controls.RemoveAt(0); c.Dispose(); }
            for (int k = 0; k < s.Values.Length; k++)
            {
                string roles = k < s.Sorted ? "ORD" : "PENDIENTE";
                Color fill = k < s.Sorted ? Color.FromArgb(220, 252, 231) : Color.FromArgb(248, 250, 252);
                if (s.Kind == "Swap" && (k == s.I || k == s.J)) { roles = "CAMBIO"; fill = Color.FromArgb(252, 231, 243); }
                else {
                    if (k == s.Min) { roles = "MIN"; fill = Color.FromArgb(254, 240, 138); }
                    if (k == s.J && s.Kind == "Compare") { roles = "J"; fill = Color.FromArgb(224, 242, 254); }
                }
                if (k == s.I) roles += " / i";
                if (k == s.J && s.Kind == "NewMinimum") roles += " / j";
                int fittedWidth = Math.Max(70, Math.Min(112, (array.ClientSize.Width - 24) / s.Values.Length - 12));
                int cardWidth = Math.Max(fittedWidth, s.Values[k].Length * 13 + 24);
                Panel card = new Panel { Width = cardWidth, Height = 140,
                    BackColor = fill, Margin = new Padding(6), BorderStyle = BorderStyle.FixedSingle };
                Label pos = new Label { Text = "a[" + k + "] · pos. " + (k + 1), Dock = DockStyle.Top, Height = 27, Font = new Font("Segoe UI", 9F), TextAlign = ContentAlignment.MiddleCenter };
                Label value = new Label { Text = s.Values[k], Dock = DockStyle.Fill, Font = new Font("Segoe UI", 22F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
                Label role = new Label { Text = roles, Dock = DockStyle.Bottom, Height = 26, Font = new Font("Segoe UI", 9F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
                card.Controls.Add(value); card.Controls.Add(pos); card.Controls.Add(role); array.Controls.Add(card);
            }
            array.ResumeLayout();
            indices.Text = s.Title + "     i = " + ValueOrDash(s.I) + "     j = " + ValueOrDash(s.J) + "     min = " + ValueOrDash(s.Min) + "     (índices desde 0)";
            if (s.Kind == "Swap") indices.Text = s.Title + "     Se muestran los dos destinos del intercambio.";
            explanation.Text = s.Message;
            status.Text = "Paso " + (cursor + 1) + "/" + steps.Count + "   C: " + s.Comparisons + "   I: " + s.Swaps;
            code.SelectedIndex = s.Line;
            previous.Enabled = cursor > 0; next.Enabled = cursor < steps.Count - 1; play.Enabled = steps.Count > 1;
            play.Text = timer.Enabled ? "Pausar" : "Automático";
        }
        private static string ValueOrDash(int value) { return value < 0 ? "—" : value.ToString(); }
    }
}
