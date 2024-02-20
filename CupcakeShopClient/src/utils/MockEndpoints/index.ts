import { AxiosInstance } from "axios";
import MockAdapter from "axios-mock-adapter";
import { Product } from "../../store/types/product";
import mockBestsellersEndpoint from "./mockBestsellersEndpoint";
import mockCatalogEndpoint from "./mockCatalogEndpoint";
import { mockProductDetailsEndpoint } from "./mockProductDetailsEndpoint";
import mockRecommendedProducts from "./mockRecommendedProducts";
import { mockAdditionalProductParameterEndpoint } from "./mockAdditionalProductParameterEndpoint";

const mockApi = (baseApi: AxiosInstance) => {

    function parseQueryString(url: string) {
        const queryString = url.replace(/.*\?/, "");

        if (queryString === url || !queryString) {
            return null;
        }

        const urlParams = new URLSearchParams(queryString);
        const result: any = {};

        urlParams.forEach((val, key) => {
            if (result.hasOwnProperty(key)) {
                result[key] = [result[key], val];
            } else {
                result[key] = val;
            }
        });

        return result;
    }

    const mock = new MockAdapter(baseApi);

    const randomize = (array: Product[]) => {
        let currentIndex = array.length;
        let randomIndex;

        while (currentIndex > 0) {
            randomIndex = Math.floor(Math.random() * currentIndex);
            currentIndex--;

            [array[currentIndex], array[randomIndex]] = [array[randomIndex], array[currentIndex]];
        }
    };

    mockBestsellersEndpoint(mock, randomize);
    mockCatalogEndpoint(mock, parseQueryString);
    mockProductDetailsEndpoint(mock, parseQueryString);
    mockAdditionalProductParameterEndpoint(mock);
    mockRecommendedProducts(mock, parseQueryString);

}
export default mockApi;