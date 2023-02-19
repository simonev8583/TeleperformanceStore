import React, { ChangeEvent, Fragment, useEffect, useState } from "react";
import {
  Alert,
  Button,
  Card,
  CardBody,
  CardFooter,
  CardTitle,
  Input,
  Label,
} from "reactstrap";
import { useProduct } from "../../../hooks/useProduct";
import { Product } from "../../../models/product/product.model";
import { useParams } from "react-router";

const ProductPage = () => {
  const {
    addProduct,
    productMessage,
    productStatus,
    getProduct,
    productDetail,
    updateProduct,
    clearProductDetail,
  } = useProduct();
  const [isEdit, setIsEdit] = useState<boolean>(false);
  const [title, setTitle] = useState<string>("");
  const [titleError, setTitleError] = useState<string>("");

  const [description, setDescription] = useState<string>("");
  const [descriptionError, setDescriptionError] = useState<string>("");

  const [price, setPrice] = useState<string>("");
  const [priceError, setPriceError] = useState<string>("");

  const [stock, setStock] = useState<string>("");
  const [stockError, setStockError] = useState<string>("");

  const { id }: any = useParams();

  useEffect(() => {
    clearProductDetail();
    if (id) {
      setIsEdit(true);
      getProduct(id);
      setDefaultData();
    }
  }, []);

  const setDefaultData = () => {
    setTimeout(() => {
      setTitle(productDetail.title);
      setDescription(productDetail.description);
      setPrice(productDetail.price.toString());
      setStock(productDetail.stock.toString());
    }, 500);
  };

  const onChangeTitle = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;

    setTitle(value);

    if (!value) {
      setTitleError("El campo no puede estar vacio!");
      return;
    }

    setTitleError("");
  };

  const onChangeDescription = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;

    setDescription(value);

    if (!value) {
      setDescriptionError("El campo no puede estar vacio!");
      return;
    }

    setDescriptionError("");
  };

  const onChangePrice = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;

    setPrice(value);

    if (!value || parseInt(value) < 0) {
      setPriceError("El campo no puede estar vacio!");
      return;
    }

    setPriceError("");
  };

  const onChangeStock = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;

    setStock(value);

    if (!value || parseInt(value) < 0) {
      setStockError("El campo no puede estar vacio!");
      return;
    }

    setStockError("");
  };

  const onSubmit = () => {
    const product = {
      title,
      description,
      price: parseFloat(price),
      stock: parseInt(stock),
    } as Product;

    if (isEdit) {
      product.id = id;
      updateProduct(product);
      return;
    }

    addProduct(product);
  };

  return (
    <Fragment>
      {!!productMessage && (
        <Alert color={productStatus ? "primary" : "warning"}>
          {productMessage}
        </Alert>
      )}
      <Card style={{ alignContent: "center", alignItems: "center" }}>
        <CardTitle>
          <h1>{isEdit ? "Editar producto " : "Crear un nuevo producto"}</h1>
        </CardTitle>
        <CardBody>
          <div className="row col-12">
            <div className="formInput col-6">
              <Label>Titulo</Label>
              <Input
                name="title"
                placeholder="Ingresa tu nombre de tu producto"
                value={title}
                onChange={onChangeTitle}
              />
              {titleError && <span style={{ color: "red" }}>{titleError}</span>}
            </div>
            <div className="formInput col-6">
              <Label>Descripción</Label>
              <Input
                name="description"
                placeholder="Ingresa la descripción del producto"
                value={description}
                onChange={onChangeDescription}
              />
              {descriptionError && (
                <span style={{ color: "red" }}>{descriptionError}</span>
              )}
            </div>
            <div className="formInput col-6">
              <Label>Precio del producto</Label>
              <Input
                name="price"
                type="number"
                placeholder="Ingresa el precio"
                value={price}
                onChange={onChangePrice}
              />
              {priceError && <span style={{ color: "red" }}>{priceError}</span>}
            </div>

            <div className="formInput col-6">
              <Label>Unidades disponibles</Label>
              <Input
                name="stock"
                type="number"
                placeholder="Ingresa las unidades disponibles"
                value={stock}
                onChange={onChangeStock}
              />
              {stockError && <span style={{ color: "red" }}>{stockError}</span>}
            </div>
          </div>
        </CardBody>
        <CardFooter>
          <div className="row col-12">
            <div className="col-8">
              <Button
                color="primary"
                disabled={
                  !!titleError || !!descriptionError || !!priceError || !stock
                }
                onClick={onSubmit}
              >
                {isEdit ? "Editar" : "Guardar"}
              </Button>
            </div>
          </div>
        </CardFooter>
      </Card>
    </Fragment>
  );
};

export default ProductPage;
