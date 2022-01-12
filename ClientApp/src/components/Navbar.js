import React from "react";
import { NavLink } from "react-router-dom";

export default function Navbar() {
	return (
		<div className="nav">
			<NavLink to="/">Converter</NavLink>
			<NavLink to="/history">History</NavLink>
		</div>
	);
}
