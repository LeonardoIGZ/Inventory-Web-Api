import React from "react";
import { BsGithub, BsTwitter, BsFacebook, BsGoogle, BsInstagram } from "react-icons/bs";
import '../../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../css/footer.css';


function Footer() {
    return (
        <div className="bg-light text-center text-lg-start text-dark">
            <div className="container p-4">
                <div className="row">
                    <div className="col-lg-6 col-md-12 mb-4 mb-md-0">
                        <h5 className="text-uppercase">Contactos</h5>
                        <h6>Tel. 4451011851</h6>
                        <h6>Correo. inventarios@northwind.com.mx</h6>
                    </div>
                    <div className="col-lg-6 col-md-12 mb-4 mb-md-0 align-items-end">
                        <h5 className="text-uppercase">Redes</h5>
                        <div className="container p-0 pb-0">
                            <section className="mb-1">
                                <a className="btn btn-primary btn-floating m-1" style={{ backgroundcolor: "#3b5998" }} href="#!"><BsFacebook size="1.5em"/></a>

                                <a className="btn btn-primary btn-floating m-1" style={{ backgroundcolor: "#55acee" }} href="#!"><BsTwitter size="1.5em"/></a>

                                <a className="btn btn-primary btn-floating m-1" style={{ backgroundcolor: "#dd4b39" }} href="#!"><BsGoogle size="1.5em"/></a>

                                <a className="btn btn-primary btn-floating m-1" style={{ backgroundcolor: "#ac2bac" }} href="#!"><BsInstagram size="1.5em"/></a>

                                <a className="btn btn-primary btn-floating m-1" backgroundcolor="#333333" style={{ backgroundcolor: "#333333" }} href="www.github.com">
                                    <BsGithub size="1.5em" color="#FFF"/></a>
                            </section>
                        </div>
                    </div>
                </div>
            </div>

            <div className="text-center p-3 back-color">
                © 2022 Copyright:
                <a className="text-dark" href="/">northwind.com.mx</a>
            </div>
        </div>
    );
}

export default Footer;
