# Supporting Documentation for Technical Assignment - Part Three

# Overview
Improving relevance in Algolia involves configuring the record index to optimise the search experience for your users. This involves setting the right parameters and attributes to search and rank the results. 

The changes made to Relevance, via the Dashboard, aim to enhance the search experience by controlling the precision of typos, setting the number of hits per page, defining searchable attributes, and setting up custom ranking rules.

# Implementation
The following improvements to relevance where made via the Dashboard to the products index configuration:
* The Relevance settings identifies the brand and categories attributes for faceting, and the rating and popularity attributes for custom ranking. 
* As the indexed data is all in English, the settings have been configured to maximise relevance by setting the search language to English.
* The settings configuration also assumes that the ignorePlurals and removeStopWords attributes are used to control the handling of plurals and stop words. 
* The alternativesAsExact attribute is set to ignorePlurals and singleWordSynonym, which means that Algolia will treat plural forms and single-word synonyms as exact matches.

# Additional Files
Please find attached an export of my index settings that you can import via the Dashboard to quickly replicate the relevance settings described above - export-index-configuration.json.



