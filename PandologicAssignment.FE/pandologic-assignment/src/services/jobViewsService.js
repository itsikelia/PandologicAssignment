import axios from "axios";
export default function jobViewsEndpoint() {
    const endpoint = axios.create({
        baseURL: "https://localhost:7041",
    });

    const getJobViewsData = async (from , to) => {
        return await endpoint.post('/JobViews/GetJobViewDataByDateRange' , {from , to})
    }

    return { getJobViewsData };
}