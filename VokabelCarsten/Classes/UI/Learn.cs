using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VokabelCarsten.Classes.UI
{
    [Activity(Label = "Learn1")]
    public class Learn1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LearnModus1);

            // Get Ui Elements
            Button vokabelQuery = FindViewById<Button>(Resource.Id.VokableQuery);
            Button showSolution = FindViewById<Button>(Resource.Id.showSolution);
            Button solutionWasKnown = FindViewById<Button>(Resource.Id.SolutionKnown);
            Button solutionWasNotKnown = FindViewById<Button>(Resource.Id.SolutionNotKnown);
            LinearLayout answerView = FindViewById<LinearLayout>(Resource.Id.AnswerContainerView);

            //Ask First Question
            //vokabelQuery.Text = ;

            //Handle Show Solution Button
            showSolution.Click += delegate
            {
                showSolution.Visibility = ViewStates.Gone;
                answerView.Visibility = ViewStates.Visible;
                //Replace Question with Solution
                //vokabelQuery.Text = ;
            };

            //Handle Solution was Known Button
            solutionWasKnown.Click += delegate
            {
                showSolution.Visibility = ViewStates.Visible;
                answerView.Visibility = ViewStates.Gone;

                //selectVocabCheck(1);
                //ToDo: Increment Level By one
                //Ask new Question
                //vokabelQuery.Text = ;
            };

            //Handle Solution was not Known Button
            solutionWasNotKnown.Click += delegate
            {
                showSolution.Visibility = ViewStates.Visible;
                answerView.Visibility = ViewStates.Gone;

                //selectVocabCheck(0);
                //ToDo: Decrement Level By One
                //Ask new Question
                //vokabelQuery.Text = ;
            };
        }
    }
}