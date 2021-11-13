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

> STEPS TO RUN THE API TO GET THE DATA
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
    
