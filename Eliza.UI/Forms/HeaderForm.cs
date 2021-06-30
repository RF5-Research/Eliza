using Eliza.UI.Helpers;
using Eliza.UI.Widgets;
using Eto.Forms;

namespace Eliza.UI.Forms
{
    class HeaderForm : Form
    {
        public HeaderForm(Model.SaveData.SaveData save)
        {
            Title = "Header";

            var header = save.header;
            var stackLayout = new VBox();

            //Until Eto changes Value to decimal...
            //var uid = new SpinBox(new Ref<ulong>(() => header.uid, v => { header.uid = v; }), "UID");
            var uid = new SpinBox("UID");
            uid.numericStepper.Enabled = false;
            var version = new SpinBox(new Ref<uint>(() => header.version, v => { header.version = v; }), "Version");

            var project = new LineEdit(new Ref<char[]>(() => header.project, v => { header.project = v; }), "Project");
            project.textBox.Enabled = false;
            project.textBox.MaxLength = 4;

            var wCnt = new SpinBox(new Ref<uint>(() => header.wCnt, v => { header.wCnt = v; }), "WCnt");
            var wOpt = new SpinBox(new Ref<uint>(() => header.wOpt, v => { header.wOpt = v; }), "WOpt");

            var saveTime = new GroupBox() { Text = "Save Time" };
            var saveTimeStackLayout = new VBox();

            var year = new SpinBox(new Ref<ushort>(() => header.saveTime.year, v => { header.saveTime.year = v; }), "Year");
            var day = new SpinBox(new Ref<ushort>(() => header.saveTime.day, v => { header.saveTime.day = v; }), "Day");
            var month = new SpinBox(new Ref<byte>(() => header.saveTime.month, v => { header.saveTime.month = v; }), "Month");
            var hour = new SpinBox(new Ref<byte>(() => header.saveTime.hour, v => { header.saveTime.hour = v; }), "Hour");
            var minute = new SpinBox(new Ref<byte>(() => header.saveTime.minute, v => { header.saveTime.minute = v; }), "Minute");
            var second = new SpinBox(new Ref<byte>(() => header.saveTime.second, v => { header.saveTime.second = v; }), "Second");

            StackLayoutItem[] saveTimeStackLayoutItems =
            {
                    year,
                    day,
                    month,
                    hour,
                    minute,
                    second
                };

            foreach (var item in saveTimeStackLayoutItems)
            {
                saveTimeStackLayout.Items.Add(item);

            }

            saveTime.Content = saveTimeStackLayout;

            //This isn't a header member, but it should be
            var slotNo = new SpinBox(new Ref<int>(() => save.saveData.slotNo, v => { save.saveData.slotNo = v; }), "Slot Number");

            StackLayoutItem[] stackLayoutItems =
            {
                    uid,
                    version,
                    project,
                    wCnt,
                    wOpt,
                    saveTime,
                    slotNo
            };

            foreach (var item in stackLayoutItems)
            {
                stackLayout.Items.Add(item);

            }

            Content = stackLayout;
        }
    }
}
