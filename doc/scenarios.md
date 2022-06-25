# Сценарии

### find_by_term

Возвращает все внутренние идентификаторы документов в которых в указанном поле содержется указанный терм.

```
find_by_term (fld_id, term) : doc_id[]
{
    // находим внутренний идентификатор терма.
    get_term_id (term) : term_id -> using ( term.ix.NN.seg )
    // находим все внутренние идентификаторы документов в которых в указанном поле содержится указанный терм.
    get_doc_id (fld_id, term_id) : doc_id[]  -> using ( field.FF.td.ix.NN.seg )

    return doc_id[]
}
```

### find_by_doc_id

Возвращает все термы для документа с указанным ключём.

```
find_by_doc_id (fld_id, term) : term[]
// fld_id - ключевое поле документа
// term - значение ключа
{
    // находим внутренний идентификатор документа.
    find_by_term (fld_id, term) : doc_id
    // получаем все внутренние идентификаторы термов для всех полей найденного документа
    get_term_id (fld_id, doc_id) : term_id[] -> using ( doc.NN.seg )
    // получаем значения всх термов.
    get_term (term_id[]) : term[] -> using ( terms.NN.seg )

    return term[]
}
```
