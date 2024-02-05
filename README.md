# Zuyd Wayfinder

Welcome to the Zuyd Wayfinder.

## How to Use:
First create an account and then login. After that you can go to events and create an event. Here you can also enter the event and also create activity's.
With these pages they all have details pages where you can see location, weather and descriptions. You can also logout or see your own account details.

## Running on Windows.
When creating an account it sends an notification but on windows it can't so it throws an error.

## Running on Android.
Make sure you enable notifications otherwise you won't receive the welcome notification when creating an account.
(Code for notification is in the XAML.CS of the CreateAccountPage.)

## API
I have added 1 / 2 API's
One is ofcourse to run the Python scripts from Algorithms. Only this doesn't work currently because there are some issues with the returning values.
And I also added an weather API that display's the current weather for an event. Because I ran in to some issues with combining Date and Time. I made the decision to show the function on the pages but it always takes the DateTime.Now();
With that I can cycle through 14 days of weather forecast but now choose to only display the current weather of today.
The code for showing the weather is on the (My)EventDetailsPage.
