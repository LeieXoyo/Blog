import { useEffect, useState } from "react"

export const Article = props => {
    const [articles, setArticles] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getAllArticleData();
    }, []);

    async function getAllArticleData() {
        const response = await fetch('api/Article');
        const data = await response.json();
        setArticles(data);
        setLoading(false);
    };


    function modalAction(e, tag, action) {
        const element = window.document.getElementById(`article_modal_${tag}`);
        if (element !== null)
        {
            if (action === 'show') {
                element.showModal();
            }
            if (action === 'close') {
                element.close();
            }
        }
    }

    async function pushArticle(e) {
        console.log(e)
        let data = {
            title: e.target.title.value,
            author: e.target.author.value,
            content: e.target.content.value,
        };
        const response = await fetch(
            'api/Article',
            {
                method: "POST",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data),
            }
        );
        console.log(response.json());
        window.location.reload()
    }

    return (
        <>
            <div className="grid grid-flow-row-dense grid-cols-2 gap-4 lg:grid-cols-4">
            {
                loading ? <span className="loading loading-ring loading-lg"></span> : articles.map(a => {
                    return (
                        <div key={a.id}>
                            <div className="card card-compact bg-base-100 shadow-xl">
                                <div className="card-body">
                                    <h2 className="card-title">{a.title}</h2>
                                    <p>{a.author}</p>
                                    <div className="card-actions justify-end">
                                        <button className="btn btn-primary" onClick={(e) => modalAction(e, a.id, 'show')}>打开</button>
                                    </div>
                                </div>
                            </div>
                            <dialog id={`article_modal_${a.id}`} className="modal backdrop-blur-sm" >
                                <form method="dialog" className="w-4/5 h-4-5 lg:w-2/3 lg:h-2/3">
                                    <div className="card card-compact bg-base-100 shadow-xl">
                                        <div className="card-body">
                                            <h2 className="card-title">{a.title}</h2>
                                            <div className="badge badge-secondary badge-outline">{a.author}</div>
                                            <div className="divider"></div> 
                                            <p>{a.content}</p>
                                            <div className="divider"></div> 
                                            <div>
                                                <div className="badge badge-accent badge-outline">{atob(a.updatedAt)}</div>
                                                <div className="card-actions justify-end">
                                                    <button className="btn btn-accent" onClick={(e) => modalAction(e, a.id, 'close')}>关闭</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </dialog>
                        </div>
                    )
                })
            }
            </div>
            <button className="btn btn-neutral fixed bottom-4 right-4" onClick={(e) => modalAction(e, 'create', 'show')}>新增</button>
            <dialog id={`article_modal_create`} className="modal backdrop-blur-sm" >
                <form method="dialog" className="w-4/5 h-4-5 lg:w-2/3 lg:h-2/3" onSubmit={(e) => pushArticle(e)}>
                    <div className="card card-compact bg-base-100 shadow-xl">
                        <div className="card-body">
                            <h2 className="card-title">新增</h2>
                            <input type="text" name="title" placeholder="标题" className="input input-bordered input-primary w-full max-w-xs" />
                            <input type="text" name="author" placeholder="作者" className="input input-bordered input-secondary w-full max-w-xs" />
                            <textarea className="textarea textarea-accent" name="content" placeholder="内容"></textarea>
                            <div className="card-actions justify-end">
                                <button className="btn btn-accent" type="submit">提交</button>
                                <button className="btn btn-accent" type="button" onClick={(e) => modalAction(e, 'create', 'close')}>取消</button>
                            </div>
                        </div>
                    </div>
                </form>
            </dialog>
        </>
    );
}
