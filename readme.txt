Requirement: User should be able to order and filter the list by date, status and category
	- Order and filter events by it's category is not available in EONET API. Can be done at category list but not at event list.
	- Sort/filter by date it implies that the event must have closed status. To this case, is notified in front-end. Also, EONET API don't provide a search option for date, 
	  so in this case, first I pick data with closed status and then I sort/filter that to emulate the call. For having the correct results EONET should provide a Date filter/sort.


Solution:
	- I have made the solution as simple as possible, I made it with Angular instead React due to my limited time. 
          Doing it with React would only take more time, not more complexity

Improvements:
	- Backend: Adapter to communicate with EONET, Wrapper for httpClient calls, Deserialization in new clases, Url configured at appsettings(Web.config) and not harcoded
	- Frontend: Save last event search, keep filters, Wrapper for httpClient, Style, UI Framework, correct components for loading, table, etc. Url configured at appsettings(Web.config) and not harcoded

I hope it helps.
Thank you!

