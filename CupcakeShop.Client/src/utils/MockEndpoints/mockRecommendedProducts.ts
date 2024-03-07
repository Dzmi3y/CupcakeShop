import { Product } from "../../store/types/product";
import productsList from "../../configs/data.json";
import MockAdapter from "axios-mock-adapter";

const mockRecommendedProducts = (mock: MockAdapter, parseQueryString: (url: string) => any) => {

    //mock.onGet(/\/recomendations\/?(.*)/).reply((config) => {
    //    let params = parseQueryString(config.url as string);

    //    let id: number | undefined = params.id as number;
    //    let count: number | undefined = params.count as number;

    //    let recommendedProduct: Product[] = [];
    //    if (count) {
    //        recommendedProduct = (productsList as Product[]).slice(0, count);
    //    }

    //    return [200, recommendedProduct];
    //});
}

export default mockRecommendedProducts;