using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace ProblemuRegistravimas.AndroidProject.Fragments
{
    public class ListClosedProblemsFragment : Fragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.ListClosedProblems, null);
        }
    }
}