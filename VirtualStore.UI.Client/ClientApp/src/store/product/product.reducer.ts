import { ProductActionType } from "./product.types";

const initialState = {
  products: [],
  productsOwn: [],
  message: "",
  status: false,
  detail: null,
};

export default (state = initialState, action: any) => {
  switch (action.type) {
    case ProductActionType.GET_PRODUCTS:
      return {
        ...state,
        products: action.payload,
      };

    case ProductActionType.GET_PRODUCTS_OWN:
      return {
        ...state,
        productsOwn: action.payload,
      };

    case ProductActionType.ADD_PRODUCT:
      return {
        ...state,
        message: !!action.payload
          ? "Se agregó un nuevo producto"
          : "Ocurrió un error",
        status: !!action.payload,
      };

    case ProductActionType.GET_PRODUCT_DETAIL:
      return {
        ...state,
        detail: action.payload,
      };

    case ProductActionType.UPDATE_PRODUCT:
      return {
        ...state,
        message: !!action.payload ? "Se editó el producto" : "Ocurrió un error",
        status: !!action.payload,
      };

    case ProductActionType.REMOVE_PRODUCT:
      return {
        ...state,
      };

    default:
      return state;
  }
};
