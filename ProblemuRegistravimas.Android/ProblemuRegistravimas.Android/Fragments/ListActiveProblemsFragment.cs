using System;
using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ProblemuRegistravimas.AndroidProject.Activities;
using ProblemuRegistravimas.AndroidProject.Adapters;
using ProblemuRegistravimas.AndroidProject.Http;
using static Android.Support.V7.Widget.RecyclerView;
using Fragment = Android.Support.V4.App.Fragment;

namespace ProblemuRegistravimas.AndroidProject.Fragments
{
    public class ListActiveProblemsFragment : Fragment
    {
        private IHttpService _httpService;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _httpService = new HttpService();

            RecyclerView recyclerView = (RecyclerView)inflater.Inflate(
                Resource.Layout.recycler_view, container, false);

            ContentAdapter adapter = new ContentAdapter(_httpService.GetProblems("Assigned"));
            adapter.ItemClick += Adapter_ItemClick;
            recyclerView.SetAdapter(adapter);
            recyclerView.HasFixedSize = true;
            recyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            return recyclerView;
        }

        private void Adapter_ItemClick(object sender, Models.Problem e)
        {
            Intent i = new Intent(Context, typeof(ViewProblem));
            i.PutExtra("PROBLEM_ID", e.Id);
            StartActivity(i);
        }
    }
}