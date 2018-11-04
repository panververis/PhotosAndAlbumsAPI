This is a small project using .Net Core 2.1 Web API and NUnit + NUnit Test Adapter (both 3.11).

Implements an API that uses two different Urls to fetch a number of Photos and Albums data, and then:
i)  Combine them, and expose that as an API.
ii) Secondly, it will also allow for filtering using a user ID.


Information on the code and the decisions taken while bulding it:

This exercise took a total of about 4,5 hours.

The project has the following structure, described from a higher-level perspective:
There are 2 core services, the "Albums" and the "Photos" service. These are each referencing their respective Urls,
the two that were provided in the exercise's description.
The results of these two (which are Enumerables of Albums and Photos, respectively) are combined using the "AlbumsAndPhotosHelper" class.
That happens within the "AlbumsAndPhotosService" class, which is essentialy the Service that provides the API's date,
by making use, and combining the results of, the underlying Albums and Photos Services.

NOTES ON THE CODE:
i)   I have attempted to write Unit Tests as per the instructions and give a good coverage. However do note that Unit Tests for the
Albums and Photos Services are NOT there, as that would mean that I would have to mock their 
IHttpClientFactory / IHttpClient and IConfiguration dependencies, and I think that falls out of the scope of this exercise.
ii)  A good performance improvement on the "Helper" class for example would be to have it yield return the "aggregated"
results, insted of returning a big chunky List.
iii) I made the decision to keep the two ways of hitting the endpoint (for all Albums+Photos, or for a specific user) in two 
separate Controller Actions, as I believe that would be cleaner. They are also Unit Tested separately.
iv)  As you can also see, a good example of how DI can be so effortlesly used in .Net Core is in the Startup class,
where in the "ConfigureServices" method I am registering all of my dependencies

I will be very happy for us to go over my solution and its structure, and share thoughs on it!