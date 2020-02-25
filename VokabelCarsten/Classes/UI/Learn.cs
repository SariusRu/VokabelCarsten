using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace VokabelCarsten.Classes.UI
{
    [Activity(Label = "Learn1")]
    public class Learn1 : Activity
    {
        // Get Ui Elements
        Button vokabelQuery;
        Button showSolution;
        Button solutionWasKnown;
        Button solutionWasNotKnown;
        LinearLayout answerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LearnModus1);

            // Get Ui Elements
            vokabelQuery = FindViewById<Button>(Resource.Id.VokableQuery);
            showSolution = FindViewById<Button>(Resource.Id.showSolution);
            solutionWasKnown = FindViewById<Button>(Resource.Id.SolutionKnown);
            solutionWasNotKnown = FindViewById<Button>(Resource.Id.SolutionNotKnown);
            answerView = FindViewById<LinearLayout>(Resource.Id.AnswerContainerView);
            
            //Handle Show Solution Button
            showSolution.Click += delegate
            {
                
            };

            //Handle Solution was Known Button
            solutionWasKnown.Click += delegate
            {

            };

            //Handle Solution was not Known Button
            solutionWasNotKnown.Click += delegate
            {
                
            };
        }

        public void showQuestion(string Question)
        {
            showSolution.Visibility = ViewStates.Visible;
            answerView.Visibility = ViewStates.Gone;
            //Replace Question with Solution
            vokabelQuery.Text = Question;
        }

        public void showAnswer(string Answer)
        {
            showSolution.Visibility = ViewStates.Gone;
            answerView.Visibility = ViewStates.Visible;
            //Replace Question with Solution
            vokabelQuery.Text = Answer;
        }
    }
}