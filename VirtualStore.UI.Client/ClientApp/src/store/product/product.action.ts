import { Dispatch } from "redux";
import productService from "./product.service";
import { ProductActionType } from "./product.types";
import { Product } from "../../models/product/product.model";

class ProductAction {
  getProductsAction = () => async (dispatch: Dispatch) => {
    const promise = productService.getProducts();

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: ProductActionType.GET_PRODUCTS, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };

  getProductsOwnAction = () => async (dispatch: Dispatch) => {
    const promise = productService.getProductsOwn();

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: ProductActionType.GET_PRODUCTS_OWN, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };

  addProductAction = (product: Product) => async (dispatch: Dispatch) => {
    const promise = productService.addProduct(product);

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: ProductActionType.ADD_PRODUCT, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };

  getProductAction = (id: string) => async (dispatch: Dispatch) => {
    const promise = productService.getProduct(id);

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: ProductActionType.GET_PRODUCT_DETAIL, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };

  updateProductAction = (product: Product) => async (dispatch: Dispatch) => {
    const promise = productService.updateProduct(product);

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: ProductActionType.UPDATE_PRODUCT, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };

  removeProductAction = (productId: string) => async (dispatch: Dispatch) => {
    const promise = productService.removeProduct(productId);

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: ProductActionType.REMOVE_PRODUCT, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };

  clearProductDetailAction = () => async (dispatch: Dispatch) => {
    try {
      dispatch({ type: ProductActionType.GET_PRODUCT_DETAIL, payload: null });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };
}

export default new ProductAction();
