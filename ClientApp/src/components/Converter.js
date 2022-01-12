import React, { useState } from "react";
import { Currencies } from "../Currencies";

export default function Converter() {
	const [from, setFrom] = useState();
	const [to, setTo] = useState();
	const [amount, setAmount] = useState();
	const [output, setOutput] = useState();

	const requestBody = {
		from,
		to,
		amount: parseInt(amount),
	};

	async function convert(e) {
		e.preventDefault();
		const response = await fetch("api/Conversions", {
			method: "POST",
			headers: {
				"Content-Type": "application/json; charset=UTF-8",
			},
			body: JSON.stringify(requestBody),
		});

		const data = await response.json();
		setOutput(data.output);
		console.log(data);
	}

	return (
		<div className="converter">
			<form onSubmit={convert}>
				<div>
					<label>From </label>
					<select
						name=""
						id=""
						className=""
						onChange={(e) => setFrom(e.target.value)}
					>
						<option value="0">Select Currency</option>
						{Currencies.map((c, id) => (
							<option key={id} value={c.trim()}>
								{c.trim()}
							</option>
						))}
					</select>
					<input
						type="text"
						value={amount}
						onChange={(e) => setAmount(e.target.value)}
					/>
				</div>
				<div>
					<label>To</label>
					<select
						name=""
						id=""
						className=""
						onChange={(e) => setTo(e.target.value)}
					>
						<option value="0">Select Currency</option>
						{Currencies.map((c, id) => (
							<option key={id} value={c.trim()}>
								{c.trim()}
							</option>
						))}
					</select>

					<input type="text" value={output} readOnly />
				</div>
				<button type="submit">Convert</button>
			</form>
		</div>
	);
}
