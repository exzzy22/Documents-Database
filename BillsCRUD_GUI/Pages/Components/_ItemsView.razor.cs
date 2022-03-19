namespace BillsCRUD_GUI.Pages.Components
{
    public partial class _ItemsView
    {
        [Parameter]
        public IEnumerable<Item> Items { get; set; }
        private bool IsToggle { get; set; } = false;

        private void Toggle()
        {
            IsToggle = !IsToggle;
        }
    }
}
