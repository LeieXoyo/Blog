import { useEffect, useState } from "react"

export const Image = props => {
    const [images, setImages] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getAllImageData();
    }, []);

    async function getAllImageData() {
        const response = await fetch('api/Image');
        const data = await response.json();
        setImages(data);
        setLoading(false);
    };

    function openImage(id) {
        const element = window.document.getElementById(`img_modal_${id}`);
        if (element !== null) {
            element.showModal();
        }
    };

    function closeImage(e, id) {
        const element = window.document.getElementById(`img_modal_${id}`);
        if (element !== null && e.target.tagName !== "IMG") {
            element.close();
        }
    };

    return (
        <>
            {
                loading ? <span className="loading loading-ring loading-lg self-center justify-self-center"></span> :
                    <div className="grid grid-flow-row-dense grid-cols-2 gap-4 lg:grid-cols-4">
                        {
                            images.map(i => {
                                return (
                                    <div key={i.id}>
                                        <figure onClick={(e) => openImage(i.id)}>
                                            <img className="rounded-lg hover:brightness-75" src={i.imgUrl} alt="图片" />
                                        </figure>
                                        <dialog id={`img_modal_${i.id}`} className="modal backdrop-blur-sm" onClick={(e) => closeImage(e, i.id)}>
                                            <form method="dialog" className="w-4/5 h-4-5 lg:w-2/3 lg:h-2/3">
                                                <figure>
                                                    <img src={i.imgUrl} alt="图片" />
                                                </figure>
                                            </form>
                                        </dialog>
                                    </div>

                                )
                            })
                        }
                    </div>
            }
        </>

    );
}