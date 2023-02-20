import productSelector from "../store/product/product.selector";
import productAction from "../store/product/product.action";
import { Product } from "../models/product/product.model";
import { useDispatch, useSelector } from "react-redux";

export const useProduct = () => {
  const products: Product[] = useSelector(productSelector.getProducts);
  const productsOwn: Product[] = useSelector(productSelector.getProductsOwn);
  const productMessage: string = useSelector(productSelector.getMessage);
  const productStatus: boolean = useSelector(productSelector.getStatus);
  const currentProductDetail: Product = useSelector(
    productSelector.getProductDetail
  );

  const dispatch = useDispatch();

  const getProducts = () => {
    dispatch(productAction.getProductsAction());
  };

  const getProductsOwn = () => {
    dispatch(productAction.getProductsOwnAction());
  };

  const addProduct = (product: Product) => {
    dispatch(productAction.addProductAction(product));
  };

  const getProduct = (id: string) => {
    dispatch(productAction.getProductAction(id));
  };

  const updateProduct = (product: Product) => {
    dispatch(productAction.updateProductAction(product));
  };

  const removeProduct = (productId: string) => {
    dispatch(productAction.removeProductAction(productId));
  };

  const clearProductDetail = () => {
    dispatch(productAction.clearProductDetailAction());
  };

  const uploadFile = (image: File, productId: string) => {
    dispatch(productAction.uploadImageAction(image, productId));
  };

  return {
    products,
    productsOwn,
    getProducts,
    getProductsOwn,
    addProduct,
    productMessage,
    productStatus,
    getProduct,
    productDetail: currentProductDetail,
    updateProduct,
    removeProduct,
    clearProductDetail,
    uploadFile,
  };
};
