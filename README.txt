Module 3 Capstone - National Park Weather Service

You have been asked to develop a web application for the National Park Weather Service.
The requirements for your application are listed below:

1. As a user of the system, I need the ability to view a list of all national parks from the home page.
a. The home page should only show a picture of the park, its name, location, and a short
summary,
2. As a user of the system, I need the ability select a park and view additional details about the selected
park. All detail described in the Park Data Source needs to be displayed.
3. As a user of the system, once I select a park for viewing I have a way of viewing its 5-day weather
forecast. Each daily forecast should provide a recommendation so that the user knows how to prepare
for the weather appropriately.
a. This may be on the same page as the park detail or on a separate page.
b. The forecast for each park can be obtained from the Weather Forecast database table.
c. If the daily forecast calls for snow, then tell the user to pack snowshoes.
d. If the daily forecast calls for rain, then tell the user to pack rain gear and wear waterproof shoes.
e. If the daily forecast calls for thunderstorms, tell the user to seek shelter and avoid hiking on
exposed ridges.
f.

If the daily forecast calls for sun, tell the user to pack sunblock.

g. If the temperature is going to exceed 75 degrees, tell the user to bring an extra gallon of water.
h. If the difference between the high and low temperature exceeds 20 degrees, tell the user to
wear breathable layers.
i.

If the temperature is going to be below 20 degrees, make sure to warn the user of the dangers
of exposure to frigid temperatures.

4. As a user of the system, I need the ability to change my temperature preference to Celsius or
Fahrenheit. My choice should be remembered while browsing the rest of the website.
5. As a user of the system, I need the ability to participate in the daily survey.

a. Today’s survey will ask the user to vote on their favorite national park. In additional to selecting
a park, they must enter values for a few required fields.
i.

E-mail address, state of residence, and physical activity level (inactive, sedentary, active,
extremely active).

b. Once the survey has been submitted and permanently saved for record, the user is redirected to
the survey results page where they see which park leads amongst all survey takers.

Data Sources
Your application will have access to the following sources of data:

Daily Weather File
A daily weather table is provided to the system that provides weather forecast data for the next 5 days. The
data columns are as follows:
Field

Description

Park Code

A short String that uniquely identifies a park. (see below for list of park
codes)

Day

The forecast day. Today is day 1, tomorrow is day 2, etc.

Low

The expected low temperature in degrees Fahrenheit

High

The expected high temperature in degrees Fahrenheit

Forecast

The expected weather. Possible values are: sunny, partly cloudy,
cloudy, rain, thunderstorms, snow

Park Data File
A park data table contains information about each park. The data columns are as follows:
Field

Description

Park Code

A short String that uniquely identifies a park. (see below for
list of park codes)

Park Name

The name of the park (e.g. “Grand Canyon National Park)

State

The state in which the park is located

Acreage

The size of the park in acres

Elevation in Feet

The park’s elevation above sea level (in feet)

Miles of Trail

The combined length of all hiking trails in the park

Number of Campsites

The total number of campsites available for visitors in the
park

Climate

A generate description of the park’s climate (e.g. “Desert”)

Year Founded

The year the park joined the National Park System

Annual Visitor Count

The average number of visitors to the park on a annual basis

Quote

A famous quote related to the park

Quote Source

The person to whom the quote is attributed

Description

A description of the park

Entry Fee

The cost to enter the park in dollars. Starts with a dollar sign.
(e.g. $10)

Number of Animal
Species

The number of different animal species that can be found
within the boundaries of the park

Park Codes
Each park has been assigned a unique park code as follows:
Park Code

Park

GNP

Glacier National Park

GCNP

Grand Canyon National Park

GTNP

Grand Teton National Park

MRNP

Mount Ranier National Park

GSMNP

Great Smoky Mountain National Park

ENP

Everglades National Park

YNP

Yellowstone National Park

YNP2

Yosemite National Park

CVNP

Cuyahoga Valley National Park

RMNP

Rocky Mountain National Park

