# Galytix.WebApi
##Galytix assessment  submission


submission by Tejas Barhate 


>STEPS TO RUN THE SOLUTION
1. Download the ZIP file of the solution and extract it.
2. Open the extracted folder in VS2022.
3. Go to the Solution Explorer and double click on the Galytix.WebApi.sln file to load the project.
4. Make sure that the we are running the debug version and press ctrl+F5.
5. Server starts running on http://localhost:9091 .
6. Paste http://localhost:9091/swagger/v1/swagger.json in the broswer to view some basic information about the endpoints present in the API.

>API ENDPOINT
1. The api endpoint is http://localhost:9091/api/gwp/avg
2. The request object looks like 
```
  {
    "country":"ao",
    "lob":["transport", "motor", "liability", "a_s"]
  }
```
3. The response data looks like
```
  {
      "transport": 42778110.4,
      "motor": 147726403.6,
      "liability": 22025795.4,
      "a_s": 168229730.5
  }
```

>SOME ASSUMPTIONS
1. The endpoint returns bad request if we pass empty country name as well as no line of businesses.
2. Since I was confused about the proper mathematical procedure  to calculate the average gross written premium (GWP), I used the following formula:
```
  average = (total of all values from 2008 to 2015)/(no. of non null values from 2008 to 2015)
```




#### HOPE I WAS ABLE TO SATISFY YOU WITH MY SOLUTION. HOPING TO HEAR POSITIVELY FROM YOU.
    
