namespace ArtGalleryFrontend.UtilityService
{
    public class UserStateService
    {
        public bool IsAdmin { get; private set; }  

        public event Action ? OnChange;

        public void SetRoleUser()
        {
            IsAdmin = false;
            NotifyStateChanged();
        }

        public void SetRoleAdmin()
        {
            IsAdmin = true;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
