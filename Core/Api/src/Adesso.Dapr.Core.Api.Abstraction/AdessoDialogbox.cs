namespace Adesso.Dapr.Core.Api.Abstraction
{
    public class AdessoDialogbox
    {
        public string mode { get; set; }
        public bool isForce { get; set; }
        public string header { get; set; }
        public string message { get; set; }
        public List<DialogboxButton> buttons { get; set; }


        public static AdessoDialogbox GetSample()
        {
            return new AdessoDialogbox
            {
                mode = "url",
                isForce = false,
                header = "Hoşgeldiniz",
                message = "https://static.vecteezy.com/system/resources/previews/010/925/820/original/colorful-welcome-design-template-free-vector.jpg",
                buttons = new List<DialogboxButton>{
                        new DialogboxButton{
                            title="Tamam",
                            action = "ok",
                        }
                    }
            };
        }
    }
    public class DialogboxButton
    {
        public string title { get; set; }
        public string action { get; set; }
    }

}