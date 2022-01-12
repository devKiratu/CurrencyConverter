import React from "react";

export default function HistoryCard({ transaction }) {
	return (
		<div className="historycard">
			<h3>Transaction {transaction.id}</h3>
			<p>Transaction Id: {transaction.id}</p>
			<p>From: {transaction.from}</p>
			<p>To: {transaction.to}</p>
			<p>Amount: {transaction.amount}</p>
			<p>Output: {transaction.output} </p>
			<p>TransactedAt: {transaction.transactedAt}</p>
		</div>
	);
}
