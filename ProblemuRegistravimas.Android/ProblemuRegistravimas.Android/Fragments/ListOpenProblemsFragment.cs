using Fragment = Android.Support.V4.App.Fragment;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using ProblemuRegistravimas.AndroidProject.Adapters;
using ProblemuRegistravimas.AndroidProject.Http;

namespace ProblemuRegistravimas.AndroidProject.Fragments
{
    public class ListOpenProblemsFragment : Fragment
    {

        private IHttpService _httpService;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _httpService = new HttpService();

            RecyclerView recyclerView = (RecyclerView)inflater.Inflate(
                Resource.Layout.recycler_view, container, false);

            ContentAdapter adapter = new ContentAdapter(_httpService.GetProblems("Open"));
            adapter.ItemClick += Adapter_ItemClick;
            recyclerView.SetAdapter(adapter);
            recyclerView.HasFixedSize = true;
            recyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            return recyclerView;
        }

        private void Adapter_ItemClick(object sender, Models.Problem e)
        {

        }
    }
}