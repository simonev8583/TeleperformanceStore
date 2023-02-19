import { store } from "../..";
import { Product } from "../../models/product/product.model";

class ProductSelector {
  getProducts = (): Product[] => {
    const state = store.getState();

    return state.products.products;
  };

  getProductsOwn = (): Product[] => {
    const state = store.getState();

    return state.products.productsOwn;
  };

  getMessage = (): string => {
    const state = store.getState();

    return state.products.message;
  };

  getStatus = (): boolean => {
    const state = store.getState();

    return state.products.status;
  };

  getProductDetail = (): Product => {
    const state = store.getState();

    return state.products.detail;
  };
}

export default new ProductSelector();
