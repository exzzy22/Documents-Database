namespace BillsCRUD_GUI.Pages.Components
{
    public partial class _ItemsView
    {
        [Parameter]
        public List<Item> Items { get; set; }
        private bool IsToggle { get; set; } = false;

        private void Toggle()
        {
            IsToggle = !IsToggle;
        }
    }
}
