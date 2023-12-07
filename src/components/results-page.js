import algoliasearch from 'algoliasearch';
import instantsearch from 'instantsearch.js';
import { clearRefinements } from 'instantsearch.js/es/lib/utils';
import { searchBox, hits, pagination, refinementList } from 'instantsearch.js/es/widgets';

import resultHit from '../templates/result-hit';

/**
 * @class ResultsPage
 * @description Instant Search class to display content on main page
 */
class ResultPage {
  constructor() {
    this._registerClient();
    this._registerWidgets();
    this._startSearch();
  }

  /**
   * @private
   * Handles creating the search client and creating an instance of instant search
   * @return {void}
   */
  _registerClient() {
    this._searchClient = algoliasearch(process.env.ALGOLIA_APP_ID, process.env.ALGOLIA_API_KEY,{
      headers: {
        'x-algolia-usertoken': 'userToken'
      }
    });

    this._searchInstance = instantsearch({
      indexName: process.env.ALGOLIA_INDEX,
      searchClient: this._searchClient,
      insights: true,
    });

    this._searchInstance
  }

  

  /**
   * @private
   * Adds widgets to the Algolia instant search instance
   * @return {void}
   */
  _registerWidgets() {
    this._searchInstance.addWidgets([
      searchBox({
        container: '#searchbox',
      }),
      hits({
        container: '#hits',
        templates: {
          item(hit, { html, sendEvent }) {
            return resultHit(hit, { sendEvent });
          },
        },
       }),
      pagination({
        container: '#pagination',
      }),
      refinementList({
        container: '#brand-facet',
        attribute: 'brand',
        limit: 8,
        showMore: true,
        showMoreLimit: 15,
      }),
      refinementList({
        container: '#categories-facet',
        attribute: 'categories',
        limit: 8,
        showMore: true,
        showMoreLimit: 15,
      }),
    ]);
  }

  /**
   * @private
   * Starts instant search after widgets are registered
   * @return {void}
   */
  _startSearch() {
    this._searchInstance.start();
  }
}

export default ResultPage;
