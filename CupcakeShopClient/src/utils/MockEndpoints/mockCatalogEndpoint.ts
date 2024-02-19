import productsList from "../../configs/data.json";
import MockAdapter from "axios-mock-adapter";

const mockCatalogEndpoint = (mock: MockAdapter) => {

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

    mock.onGet(/\/catalog\/?(.*)/).reply((config) => {
        let params = parseQueryString(config.url as string);

        let page: number | undefined = params.page as number;
        let typeid: number | undefined = params.typeid as number;
        let groupBy: number | undefined = params.groupBy as number;

        return [200, getFilteredData(page, typeid, groupBy)];
    });
}

export default mockCatalogEndpoint;