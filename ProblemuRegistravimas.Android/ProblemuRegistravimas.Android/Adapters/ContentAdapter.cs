using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ProblemuRegistravimas.AndroidProject.Models;

namespace ProblemuRegistravimas.AndroidProject.Adapters
{
     public class ContentAdapter : RecyclerView.Adapter
        {
            public List<Problem> _problems;
            public event EventHandler<Problem> ItemClick;

            public ContentAdapter(List<Problem> problems)
            {
                _problems = problems;
                
            }

            public override RecyclerView.ViewHolder
                OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                return new ListContentView(LayoutInflater.From(parent.Context), parent, OnClick);
            }

            public override void
                OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                ListContentView vh = holder as ListContentView;
                vh.Image.SetImageResource(Resource.Drawable.abc_btn_colored_material);
                vh.Description.Text = _problems[position].Description;
                vh.Title.Text = _problems[position].Name;
            }

            public override int ItemCount => _problems.Count;

            private void OnClick(int position)
            {
                ItemClick?.Invoke(this, _problems[position]);
            }

        }

    public class ListContentView : RecyclerView.ViewHolder
    {
        public ImageView Image { get; }
        public TextView Title { get; }
        public TextView Description { get; }

        public ListContentView(LayoutInflater inflater, ViewGroup parent, Action<int> listener) : base(inflater.Inflate(Resource.Layout.ListActiveProblems, parent, false))
        {
            Image = ItemView.FindViewById<ImageView>(Resource.Id.list_avatar);
            Title = ItemView.FindViewById<TextView>(Resource.Id.list_title);
            Description = ItemView.FindViewById<TextView>(Resource.Id.list_desc);

            ItemView.Click += (sender, e) => listener(AdapterPosition);
        }


    }
}