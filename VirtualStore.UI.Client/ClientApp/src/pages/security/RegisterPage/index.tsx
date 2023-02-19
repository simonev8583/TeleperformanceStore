import React, { ChangeEvent, Fragment, useState } from "react";
import { Link } from "react-router-dom";
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
import { useSecurity } from "../../../hooks/useSecurity";
import { Person } from "../../../models/person/person.model";

const RegisterPage = () => {
  const { register, userRegister } = useSecurity();
  const [isSubmit, setIsSubmit] = useState<boolean>(false);
  const [name, setName] = useState<string>("");
  const [nameError, setNameError] = useState<string>("");
  const [username, setUsername] = useState<string>("");
  const [usernameError, setUsernameError] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [passwordError, setPasswordError] = useState<string>("");

  const onChangeName = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;

    setName(value);

    if (!value) {
      setNameError("El campo no puede estar vacio!");
      return;
    }

    setNameError("");
  };

  const onChangeUsername = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;

    setUsername(value);

    if (!value) {
      setUsernameError("El campo no puede estar vacio!");
      return;
    }

    setUsernameError("");
  };

  const onChangePassword = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;

    setPassword(value);

    if (!value) {
      setPasswordError("El campo no puede estar vacio!");
      return;
    }

    setPasswordError("");
  };

  const onSubmit = () => {
    register({
      name,
      username,
      password,
    } as Person);

    setIsSubmit(true);
  };

  return (
    <Fragment>
      {isSubmit && userRegister && (
        <Alert color="success">Se a registrado</Alert>
      )}
      {isSubmit && !userRegister && <Alert color="warning">paila</Alert>}
      <Card>
        <CardTitle>
          <h1>Registrarse</h1>
        </CardTitle>
        <CardBody>
          <div className="row col-12">
            <div className="formInput col-6">
              <Label>Nombre completo</Label>
              <Input
                name="name"
                placeholder="Ingresa tu nombre"
                value={name}
                onChange={onChangeName}
              />
              {nameError && <span style={{ color: "red" }}>{nameError}</span>}
            </div>
            <div className="formInput col-6">
              <Label>Nombre de usuario</Label>
              <Input
                name="username"
                placeholder="Ingresa el usuario"
                value={username}
                onChange={onChangeUsername}
              />
              {usernameError && (
                <span style={{ color: "red" }}>{usernameError}</span>
              )}
            </div>
            <div className="formInput col-6">
              <Label>Contraseña</Label>
              <Input
                name="password"
                type="password"
                placeholder="Ingresa la contraseña"
                value={password}
                onChange={onChangePassword}
              />
              {passwordError && (
                <span style={{ color: "red" }}>{passwordError}</span>
              )}
            </div>
          </div>
        </CardBody>
        <CardFooter>
          <div className="row col-12">
            <div className="col-8">
              <Button
                color="primary"
                disabled={!!usernameError || !!passwordError || !!nameError}
                onClick={onSubmit}
              >
                Registrarse
              </Button>
            </div>

            <Link to="/">Iniciar sesión</Link>
          </div>
        </CardFooter>
      </Card>
    </Fragment>
  );
};

export default RegisterPage;
