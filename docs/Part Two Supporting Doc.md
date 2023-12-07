# Supporting Documentation for Technical Assignment - Part Two

# Overview
Algolia's Personalisation feature leverages AI to power tailored experiences for each of your users on your digital properties, driving engagement and revenue while letting you have control. 
In order to use Personalisation, data about your users behaviours is required and collected by implementing Algolia Insights. This data consists of user events that describe each user's behaviours in the last 90 days. 
Algolia then uses these events to build individual user affinity profiles that are used as a set of scored filters when personalising results.

# Code Structure
For an initial implementation of Algolia Insights, it is as simple as adding in the code below when initialising your search instance

insights: true, 

Turning on the insights option in this way achieves the following:
* Loads the search-insights library.
* Sets an anonymous user token for events and search analytics.
* Retrieves the queryID for click and conversion events.
* Sends default events from your widgets.

# Implementation
While API Clients are avilable, the Dashbaord was used enable and configure Personalization in this case and it is the recommended approach as it provides a visual simulator to simulate and explain your strategy’s effects.

In order to replicate my personalisation strategy, I have attached a screenshot of the settings I applied - Personalisation Strategy.png. 

Please note, for demoing purposes I configured a Personalisation impact of 30, however this should be reviewed and refined as part of your Personalisation strategy.

# Additional Files
Please find attached an export of my index settings that you can import via the Dashboard to help replicate the Personalisation settings described above - export-index-configuration.json.


# Useful Links
For a thorough breakdown for configuring Personalisation, please refer to the guide below
https://www.algolia.com/doc/guides/personalization/personalizing-results/in-depth/configuring-personalization/



