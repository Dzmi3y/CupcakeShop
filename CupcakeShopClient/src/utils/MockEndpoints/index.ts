import { AxiosInstance } from "axios";
import MockAdapter from "axios-mock-adapter";
import { Product } from "../../store/types/product";
import mockBestsellersEndpoint from "./mockBestsellersEndpoint";
import mockCatalogEndpoint from "./mockCatalogEndpoint";

const mockApi = (baseApi: AxiosInstance) => {
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
    mockCatalogEndpoint(mock);

}
export default mockApi;