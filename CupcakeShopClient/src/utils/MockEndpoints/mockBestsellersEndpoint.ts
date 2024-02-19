import { Product } from "../../store/types/product";
import productsList from "../../configs/data.json";
import MockAdapter from "axios-mock-adapter";
import { BestsellerEndpoint } from "../../configs";

const mockBestsellersEndpoint = (mock: MockAdapter, randomize: (p: Product[]) => void) => {
    let bestsellersList: Product[] = [];

    (productsList as Product[]).map(p => {
        let typeId = Math.floor(bestsellersList.length / 4) + 1;
        if (p.typeId === typeId)
            bestsellersList.push(p);
    }
    );

    randomize(bestsellersList);

    mock.onGet(BestsellerEndpoint).reply(200, bestsellersList);
}

export default mockBestsellersEndpoint;