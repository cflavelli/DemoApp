namespace DemoApp
{
    public static class ViewModelLocator
    {
        private static MyPageViewModel myPageVM;
        private static MyDesignPageViewModel myDesignPageVM;

        
        public static MyPageViewModel MyPageViewModel => myPageVM ?? (myPageVM = new MyPageViewModel());

        public static MyDesignPageViewModel MyDesignPageViewModel => myDesignPageVM ?? (myDesignPageVM = new MyDesignPageViewModel());
    }
}
