import productsList from "../../configs/data.json";
import MockAdapter from "axios-mock-adapter";

const mockCatalogEndpoint = (mock: MockAdapter, parseQueryString:(url: string) =>any) => {

    const getFilteredData = (pageN: number = 1, typeId?: number, groupBy: number = 15) => {
        let end = groupBy * pageN;
        let start = end - groupBy;

        const filteredPage = productsList
            .filter((p) => (!typeId) || (p.typeId == typeId));
        const list = filteredPage
            .slice(start, end);
        const totalPagesNumber = Math.ceil(filteredPage.length / groupBy);

        return { list, totalPagesNumber }
    };

    mock.onGet(/\/Product\/GetCatalogPage\/?(.*)/).reply((config) => {
        let params = parseQueryString(config.url as string);

        let page: number | undefined = params.pageNumber as number;
        let typeid: number | undefined = params.typeid as number;
        let groupBy: number | undefined = params.groupBy as number;

        return [200, getFilteredData(page, typeid, groupBy)];
    });
}

export default mockCatalogEndpoint;