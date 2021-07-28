import { AxiosResponse } from "axios";
import qs from 'qs';

import axios from "axios";

import { UrlBackEnd } from "../../../Constants/oidc-config";

import RequestService from '../../../services/request';
import EndPoints from '../../../Constants/endpoints';


const BackendBaseAddress = UrlBackEnd;

export function createCategoryRequest(categoryForm) {
    /*const formData = new FormData();

    Object.keys(categoryForm).forEach(key => {
        formData.append(key, categoryForm[key]);
    });

    return RequestService.axios.post(BackendBaseAddress + EndPoints.category, formData);*/
    //console.log("POST to " + BackendBaseAddress + EndPoints.category);

    return axios.post(BackendBaseAddress + EndPoints.category, categoryForm);
}

export function getCategoriesRequest() {
    return axios.get(BackendBaseAddress + EndPoints.category);
}

export function UpdateCategoryRequest(categoryForm) {
    /*const formData = new FormData();

    Object.keys(categoryForm).forEach(key => {
        formData.append(key, categoryForm[key]);
    });

    return RequestService.axios.put(EndPoints.brandId(brandForm.id ?? - 1), formData);*/
    //console.log("PUT to " + BackendBaseAddress + EndPoints.categoryId(categoryForm.id));

    return axios.put(BackendBaseAddress + EndPoints.categoryId(categoryForm.id), categoryForm);
}

export function DeleteCategoryRequest(id) {
    //return RequestService.axios.delete(EndPoints.brandId(brandId));
    
    return axios.delete(BackendBaseAddress + EndPoints.categoryId(id));
}