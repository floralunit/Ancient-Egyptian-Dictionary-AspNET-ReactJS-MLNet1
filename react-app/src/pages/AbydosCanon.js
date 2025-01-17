import { useEffect, useState } from "react";
import "../styles/StickyTableStyle.css";
import "../styles/FilterBar.css"
import ReactLoading from "react-loading";
import FilterBarPharaoh from "../components/filters/FilterBarPharaoh";
import { API_URL } from "../global-const.js";
import data from "../jsons/abydos.json";

export function AbydosCanon() {
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [items, setItems] = useState([]);
    const [allData, setData] = useState([]);

    // Примечание: пустой массив зависимостей [] означает, что
    // этот useEffect будет запущен один раз
    // аналогично componentDidMount()

    useEffect(() => {
        setIsLoaded(true);
        setItems(data);
        setData(data);
    })
    const handleFilterName = (name) => {
        const filteredData = items.filter((item) => {
            const fullDesc = `${item.pharaohName} ${item.englishPharaohName} ${item.nameInList}`;
            if ((fullDesc || '').toLowerCase().includes(name.toLowerCase())) {
                return item;
            }
        });

        setData(filteredData);
    };
    const handleFilterTranslit = (transliteration) => {
        const filteredData = items.filter((item) => {
            if ((item.transliteration || '').toLowerCase().includes(transliteration.toLowerCase())) {
                return item;
            }
        });

        setData(filteredData);
    };

    if (error) {
        return <div>Ошибка: {error.message}</div>;
    } else if (!isLoaded) {
        return <div className={"loadingDiv"}><ReactLoading type={"spinningBubbles"} color={"#673923"} height={'5%'}
            width={'5%'} className={"loadingBar"} /></div>;
    } else {
        return (
            <div className={"pharaohs"}>
                <div className={"empty"} />
                <div className={"container"}>
                    <div className={"row"}>
                        <div className={"col"}>
                            <div style={{ background: '#FBEEC1', borderRadius: '10px', padding: '2vh', width: '90vh', margin: '0 auto' }}>
                                <h2 align={"center"} className={"black"}>Абидосский список</h2>
                                <hr />
                                <div>
                                    <i>Абидосский список</i> — список фараонов Древнего Египта, высеченный на стене храма Сети I в Абидосе.
                                    Насчитывает 76 картушей древнеегипетских царей, начиная с Менеса и заканчивая Сети I. Был найден Мариетом.
                                    В отличие от ранее найденного, но хуже сохранившегося аналогичного списка из храма Рамсеса II, сына Сети I носит название «новой Абидосской таблицы» (la nouvelle table d’Abydos).
                                    <p />
                                    В список не включены имена фараонов I и II переходных периодов, а также пяти царей XVIII династии:
                                    Хатшепсут, Эхнатона, Сменхкара, Тутанхамона и Эйе (Хатшепсут была исключена вследствие предполагаемых гонений Тутмоса III, а четверо остальных фараонов относились к амарнскому периоду и были прокляты как еретики).
                                    <p />
                                    <img src={require('../images/abydos.jpg')} style={{ margin: '1vh auto', display: 'block' }} />
                                    Картуши расположены горизонтальными рядами. В списке каждый фараон назван только одним именем. В таблице приведено сначала то имя, которое стоит в Абидосском списке, а потом — то, под которым этот фараон более известен.
                                    <img src={require('../images/abydos1.png')} style={{ margin: '1vh auto', display: 'block' }} />
                                </div>
                                <FilterBarPharaoh
                                    onNameFilter={handleFilterName}
                                    onTranslitFilter={handleFilterTranslit}
                                />
                            </div>
                            <div className={"empty"} />
                        </div>
                        <div className={"col"}>
                            <div style={{ margin: '0 auto' }}>
                                <table className="content-table"
                                    style={{ minHeight: '40vh', margin: '0 auto', width: '90vh' }}>
                                    <thead>
                                        <tr>
                                            <th />
                                            <th>Картуш</th>
                                            <th>Имя в списке</th>
                                            <th>Транслитерация</th>
                                            <th>Фараон (ссылка на Wiki)</th>
                                            <th>Фараон (ссылка на pharaoh.se)</th>
                                            <th>Династия</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {allData?.map(item =>
                                            <tr key={item.id}>
                                                <td>{item.id}</td>
                                                {/* eslint-disable-next-line jsx-a11y/img-redundant-alt */}
                                                <td><img src={`https://pharaoh.se/svg/pharaoh/${item.id}-01-03.svg`} height={"25vh"} /></td>
                                                <td>{item.nameInList}</td>
                                                <td>{item.transliteration}</td>
                                                <td><a href={item.wikiLink}>{item.pharaohName}</a></td>
                                                <td><a href={item.pharaohSeLink}>{item.englishPharaohName}</a></td>
                                                <td>{item.dynasty}</td>
                                            </tr>)}
                                    </tbody>

                                </table>
                                <div className={"empty"} />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}