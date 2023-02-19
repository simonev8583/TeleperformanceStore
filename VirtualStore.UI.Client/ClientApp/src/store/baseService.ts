import { BASE_API, STORAGE_KEY } from "./types";
import axios, { AxiosResponse } from "axios";

export default class BaseService {
  constructor(public readonly baseApi: string = BASE_API) {}

  protected async get(url: string) {
    try {
      const queryPromise = axios.get(`${this.baseApi}${url}`, {
        headers: this.getHeaders(),
      });

      const result: AxiosResponse = await Promise.resolve(queryPromise);

      if (result.statusText !== "OK") {
        return null;
      }

      return result.data;
    } catch (error) {
      throw new Error("Ocurrio un error");
    }
  }

  protected async post(url: string, body: any) {
    try {
      const params = JSON.stringify(body);

      const path = `${this.baseApi}${url}`;

      const queryPromise = axios.post(path, params, {
        headers: this.getHeaders(),
      });

      const result: AxiosResponse = await Promise.resolve(queryPromise);

      if (result.statusText !== "OK") {
        return null;
      }

      return result.data;
    } catch (error) {
      console.log("errrrr", error);
      throw new Error("Ocurrio un error");
    }
  }

  protected async put(url: string, body: any) {
    try {
      const params = JSON.stringify(body);

      const path = `${this.baseApi}${url}`;

      const queryPromise = axios.put(path, params, {
        headers: this.getHeaders(),
      });

      const result: AxiosResponse = await Promise.resolve(queryPromise);

      if (result.statusText !== "OK") {
        return null;
      }

      return result.data;
    } catch (error) {
      console.log("errrrr", error);
      throw new Error("Ocurrio un error");
    }
  }

  protected async delete(url: string) {
    try {
      const queryPromise = axios.delete(`${this.baseApi}${url}`, {
        headers: this.getHeaders(),
      });

      const result: AxiosResponse = await Promise.resolve(queryPromise);

      if (result.statusText !== "OK") {
        return null;
      }

      return result.data;
    } catch (error) {
      throw new Error("Ocurrio un error");
    }
  }

  private getHeaders() {
    const headers: any = {};

    headers["Content-Type"] = "application/json";
    headers["Accept"] = "application/json";

    const dataStored = localStorage.getItem(STORAGE_KEY) as string;

    if (!dataStored) {
      return headers;
    }

    const store = JSON.parse(dataStored || "");

    const token = store.security!.token;
    headers["Authorization"] = `Bearer ${token}`;

    return headers;
  }
}
